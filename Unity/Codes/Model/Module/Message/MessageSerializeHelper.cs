﻿using System;
using System.IO;

namespace ET
{
    public static class MessageSerializeHelper
    {
        public static object DeserializeFrom(ushort opcode, Type type, MemoryStream memoryStream)
        {
            if (opcode < OpcodeRangeDefine.PbMaxOpcode)
            {
                return ProtobufHelper.FromStream(type, memoryStream);
            }
            
            if (opcode >= OpcodeRangeDefine.JsonMinOpcode)
            {
                return JsonHelper.FromJson(type, memoryStream.GetBuffer().ToStr((int)memoryStream.Position, (int)(memoryStream.Length - memoryStream.Position)));
            }
#if NOT_UNITY
            return MongoHelper.FromStream(type, memoryStream);
#else
            throw new Exception($"client no message: {opcode}");
#endif
        }

        public static void SerializeTo(ushort opcode, object obj, MemoryStream memoryStream)
        {
            try
            {
                if (opcode < OpcodeRangeDefine.PbMaxOpcode)
                {
                    ProtobufHelper.ToStream(obj, memoryStream);
                    return;
                }

                if (opcode >= OpcodeRangeDefine.JsonMinOpcode)
                {
                    string s = JsonHelper.ToJson(obj);
                    byte[] bytes = s.ToUtf8();
                    memoryStream.Write(bytes, 0, bytes.Length);
                    return;
                }
#if NOT_UNITY
                MongoHelper.ToStream(obj, memoryStream);
#else
                throw new Exception($"client no message: {opcode}");
#endif
            }
            catch (Exception e)
            {
                throw new Exception($"SerializeTo error: {opcode}", e);
            }

        }
        
        public static void SerializeToOuter(ushort opcode, object obj, MemoryStream memoryStream)
        {
            try
            {
                if (opcode < OpcodeRangeDefine.PbMaxOpcode)
                {
                    //erlangMogai
                    var bodyBytes = ProtobufHelper.ToBytes(obj);
                    var tMsg = new TMsg()
                    {
                        body = bodyBytes,
                        type = opcode,
                    };
                    if (obj is IRequest request)
                    {
                        tMsg.rpc_id = request.RpcId;
                    }
                    ProtobufHelper.ToStream(tMsg, memoryStream);
                    return;
                }

                if (opcode >= OpcodeRangeDefine.JsonMinOpcode)
                {
                    string s = JsonHelper.ToJson(obj);
                    byte[] bytes = s.ToUtf8();
                    memoryStream.Write(bytes, 0, bytes.Length);
                    return;
                }
#if NOT_UNITY
                MongoHelper.ToStream(obj, memoryStream);
#else
                throw new Exception($"client no message: {opcode}");
#endif
            }
            catch (Exception e)
            {
                throw new Exception($"SerializeTo error: {opcode}", e);
            }

        }

        public static MemoryStream GetStream(int count = 0)
        {
            MemoryStream stream;
            if (count > 0)
            {
                stream = new MemoryStream(count);
            }
            else
            {
                stream = new MemoryStream();
            }

            return stream;
        }
        
        /// <summary>
        /// used for outer messages, between gate, realm and client(unity)
        /// </summary>
        /// <param name="message"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static (ushort, MemoryStream) MessageToStream(object message, int count = 0)
        {
            //erlangMogai
            // MemoryStream stream = GetStream(Packet.OpcodeLength + count);
            MemoryStream stream = GetStream(count);

            ushort opcode = OpcodeTypeComponent.Instance.GetOpcode(message.GetType());
            
            // stream.Seek(Packet.OpcodeLength, SeekOrigin.Begin);
            // stream.SetLength(Packet.OpcodeLength);
            
            // stream.GetBuffer().WriteTo(0, opcode);
            
            MessageSerializeHelper.SerializeToOuter(opcode, message, stream);
            
            stream.Seek(0, SeekOrigin.Begin);
            return (opcode, stream);
        }
        
        /// <summary>
        /// used by inner messages, mainly server.
        /// </summary>
        /// <param name="actorId"></param>
        /// <param name="message"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static (ushort, MemoryStream) MessageToStream(long actorId, object message, int count = 0)
        {
            int actorSize = sizeof (long);
            MemoryStream stream = GetStream(actorSize + Packet.OpcodeLength + count);

            ushort opcode = OpcodeTypeComponent.Instance.GetOpcode(message.GetType());
            
            stream.Seek(actorSize + Packet.OpcodeLength, SeekOrigin.Begin);
            stream.SetLength(actorSize + Packet.OpcodeLength);

            // 写入actorId
            stream.GetBuffer().WriteTo(0, actorId);
            stream.GetBuffer().WriteTo(actorSize, opcode);
            
            MessageSerializeHelper.SerializeTo(opcode, message, stream);
            
            stream.Seek(0, SeekOrigin.Begin);
            return (opcode, stream);
        }
    }
}