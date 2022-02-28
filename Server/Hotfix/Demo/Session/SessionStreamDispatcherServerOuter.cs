using System;
using System.IO;

namespace ET
{
    [SessionStreamDispatcher(SessionStreamDispatcherType.SessionStreamDispatcherServerOuter)]
    public class SessionStreamDispatcherServerOuter: ISessionStreamDispatcher
    {
        public void Dispatch(Session session, MemoryStream memoryStream)
        {
            // erlangMogai
            // ushort opcode = BitConverter.ToUInt16(memoryStream.GetBuffer(), Packet.KcpOpcodeIndex);
            var tMsg = ProtobufHelper.FromStream(typeof (TMsg), memoryStream) as TMsg;
            if (tMsg == null)
            {
                Log.Error("收到一条不是我们定义tmsg的消息，跳过！");
                return;
            }
            var opcode = (ushort)tMsg.type;
            
            Type type = OpcodeTypeComponent.Instance.GetType(opcode);
            object message = null;
            if (tMsg.body!=null)
            {
                message = ProtobufHelper.FromBytes(type, tMsg.body, 0, tMsg.body.Length);
                OpcodeHelper.LogMsg(session.DomainZone(), opcode, message);
            }
            else
            {
                message = Activator.CreateInstance(type);
            }            
            if (message is IResponse response)
            {
                response.Error = tMsg.error_code;
                response.Message = tMsg.error_string;
                response.RpcId = tMsg.rpc_id;
                session.OnRead(opcode, response);
                return;
            }

            // OpcodeHelper.LogMsg(session.DomainZone(), opcode, message);
            // 普通消息或者是Rpc请求消息
            MessageDispatcherComponent.Instance.Handle(session, opcode, message);
        }
		
        public async ETTask DispatchAsync(Session session, ushort opcode, object message)
        {
            // 根据消息接口判断是不是Actor消息，不同的接口做不同的处理
            switch (message)
            {
                case IActorLocationRequest actorLocationRequest: // gate session收到actor rpc消息，先向actor 发送rpc请求，再将请求结果返回客户端
                {
                    long unitId = session.GetComponent<SessionPlayerComponent>().PlayerId;
                    int rpcId = actorLocationRequest.RpcId; // 这里要保存客户端的rpcId
                    long instanceId = session.InstanceId;
                    IResponse response = await ActorLocationSenderComponent.Instance.Call(unitId, actorLocationRequest);
                    response.RpcId = rpcId;
                    // session可能已经断开了，所以这里需要判断
                    if (session.InstanceId == instanceId)
                    {
                        session.Reply(response);
                    }
                    break;
                }
                case IActorLocationMessage actorLocationMessage:
                {
                    long unitId = session.GetComponent<SessionPlayerComponent>().PlayerId;
                    ActorLocationSenderComponent.Instance.Send(unitId, actorLocationMessage);
                    break;
                }
                case IActorRequest actorRequest:  // 分发IActorRequest消息，目前没有用到，需要的自己添加
                {
                    break;
                }
                case IActorMessage actorMessage:  // 分发IActorMessage消息，目前没有用到，需要的自己添加
                {
                    break;
                }
				
                default:
                {
                    // 非Actor消息
                    MessageDispatcherComponent.Instance.Handle(session, opcode, message);
                    break;
                }
            }
        }
    }
}