using System;
using System.IO;
using UnityEngine;

namespace ET
{
    /// <summary>
    /// 重要的类，erlangMogai
    /// </summary>
    [SessionStreamDispatcher(SessionStreamDispatcherType.SessionStreamDispatcherClientOuter)]
    public class SessionStreamDispatcherClientOuter: ISessionStreamDispatcher
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
                Log.Info("received response:"+response.ToString());
                session.OnRead(opcode, response);
                return;
            }

            // OpcodeHelper.LogMsg(session.DomainZone(), opcode, message);
            // 普通消息或者是Rpc请求消息
            MessageDispatcherComponent.Instance.Handle(session, opcode, message);
        }
    }
}