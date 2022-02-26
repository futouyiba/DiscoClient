using ET;
using ProtoBuf;
using System.Collections.Generic;
namespace ET
{
///
/// 消息头结构定义
///
	[Message(OuterOpcode.TMsg)]
	[ProtoContract]
	public partial class TMsg: Object
	{
/// 消息类型
		[ProtoMember(1)]
		public int type { get; set; }

/// 消息体
		[ProtoMember(2)]
		public byte[] body { get; set; }

		[ProtoMember(3)]
		public int rpc_id { get; set; }

///
/// 错误信息：如果消息执行错误，则回复错误编码和描述
/// error_code = 0 表示成功，否则失败
///
		[ProtoMember(4)]
		public int error_code { get; set; }

		[ProtoMember(5)]
		public string error_string { get; set; }

	}

///
/// 注册消息
///
	[Message(OuterOpcode.register_user_c2s)]
	[ProtoContract]
	public partial class register_user_c2s: Object, IMessage
	{
		[ProtoMember(1)]
		public int device_type { get; set; }

		[ProtoMember(2)]
		public string device_model { get; set; }

		[ProtoMember(3)]
		public string device_product_id { get; set; }

		[ProtoMember(8)]
		public string desc { get; set; }

         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

/// 返回
	[Message(OuterOpcode.register_user_s2c)]
	[ProtoContract]
	public partial class register_user_s2c: Object, IMessage
	{
		[ProtoMember(1)]
		public int user_id { get; set; }

         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

///
/// 获取数据中转服务endpoint
///
	[Message(OuterOpcode.get_transfer_endpoint_c2s)]
	[ProtoContract]
	public partial class get_transfer_endpoint_c2s: Object, IMessage
	{
		[ProtoMember(1)]
		public int user_id { get; set; }

		[ProtoMember(2)]
		public int endpoint_id { get; set; }

         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

/// 返回
	[Message(OuterOpcode.get_transfer_endpoint_s2c)]
	[ProtoContract]
	public partial class get_transfer_endpoint_s2c: Object, IMessage
	{
		[ProtoMember(1)]
		public string ip { get; set; }

		[ProtoMember(2)]
		public int port { get; set; }

		[ProtoMember(3)]
		public int endpoint_id { get; set; }

         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

///
/// 认证请求消息 。 device类型、id相当于一个校验的作用。
///
	[Message(OuterOpcode.authenticate_c2s)]
	[ProtoContract]
	public partial class authenticate_c2s: Object, IMessage
	{
		[ProtoMember(1)]
		public int user_id { get; set; }

		[ProtoMember(2)]
		public int device_type { get; set; }

		[ProtoMember(3)]
		public string device_product_id { get; set; }

         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

	[Message(OuterOpcode.authenticate_s2c)]
	[ProtoContract]
	public partial class authenticate_s2c: Object, IMessage
	{
         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

///
/// 心跳消息   定期30秒发一次。若30秒内没发
///
	[Message(OuterOpcode.heartbeat_c2s)]
	[ProtoContract]
	public partial class heartbeat_c2s: Object, IMessage
	{
         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

///
/// 全状态同步消息
///
	[Message(OuterOpcode.all_sync_s2c)]
	[ProtoContract]
	public partial class all_sync_s2c: Object, IMessage
	{
		[ProtoMember(1)]
		public int house_type { get; set; }

		[ProtoMember(2)]
		public int music_id { get; set; }

		[ProtoMember(3)]
		public List<int> on_lighting_ids = new List<int>();

		[ProtoMember(4)]
		public List<int> on_dj_ids = new List<int>();

		[ProtoMember(5)]
		public List<int> dj_playerids = new List<int>();

		[ProtoMember(6)]
		public List<player> players = new List<player>();

         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

	[Message(OuterOpcode.player)]
	[ProtoContract]
	public partial class player: Object
	{
		[ProtoMember(1)]
		public int player_id { get; set; }

		[ProtoMember(2)]
		public float x { get; set; }

		[ProtoMember(3)]
		public float y { get; set; }

		[ProtoMember(4)]
		public int is_dj { get; set; }

		[ProtoMember(5)]
		public float big_factor { get; set; }

		[ProtoMember(6)]
		public int figure_id { get; set; }

		[ProtoMember(7)]
		public string player_name { get; set; }

         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

///
/// 玩家进入消息
///
	[Message(OuterOpcode.player_enter_s2c)]
	[ProtoContract]
	public partial class player_enter_s2c: Object, IMessage
	{
		[ProtoMember(1)]
		public player one_player { get; set; }

         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

///
/// 玩家离开消息
///
	[Message(OuterOpcode.player_leave_s2c)]
	[ProtoContract]
	public partial class player_leave_s2c: Object, IMessage
	{
		[ProtoMember(1)]
		public int player_id { get; set; }

         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

///
/// 动作请求消息
///
	[Message(OuterOpcode.action_req_c2s)]
	[ProtoContract]
	public partial class action_req_c2s: Object, IMessage
	{
		[ProtoMember(1)]
		public int action_id { get; set; }

		[ProtoMember(2)]
		public int int1 { get; set; }

		[ProtoMember(3)]
		public int int2 { get; set; }

		[ProtoMember(4)]
		public float float1 { get; set; }

		[ProtoMember(5)]
		public float float2 { get; set; }

         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

	[Message(OuterOpcode.action_req_s2c)]
	[ProtoContract]
	public partial class action_req_s2c: Object, IMessage
	{
// 这个不是广播的。
		[ProtoMember(1)]
		public int action_id { get; set; }

		[ProtoMember(2)]
		public int int1 { get; set; }

		[ProtoMember(3)]
		public int int2 { get; set; }

		[ProtoMember(4)]
		public float float1 { get; set; }

		[ProtoMember(5)]
		public float float2 { get; set; }

         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

///
/// 动作同步消息
///
	[Message(OuterOpcode.action_syn_s2c)]
	[ProtoContract]
	public partial class action_syn_s2c: Object, IMessage
	{
		[ProtoMember(1)]
		public int player_id { get; set; }

		[ProtoMember(2)]
		public int action_id { get; set; }

		[ProtoMember(3)]
		public int int1 { get; set; }

		[ProtoMember(4)]
		public int int2 { get; set; }

		[ProtoMember(5)]
		public float float1 { get; set; }

		[ProtoMember(6)]
		public float float2 { get; set; }

         public int Error
        {
            get;
            set;
        }

        public string Message
        {
            get;
            set;
        }

        public int RpcId
        {
            get;
            set;
        }
	}

	[ResponseType(nameof(M2C_TestResponse))]
	[Message(OuterOpcode.C2M_TestRequest)]
	[ProtoContract]
	public partial class C2M_TestRequest: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string request { get; set; }

	}

	[Message(OuterOpcode.M2C_TestResponse)]
	[ProtoContract]
	public partial class M2C_TestResponse: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string response { get; set; }

	}

	[ResponseType(nameof(Actor_TransferResponse))]
	[Message(OuterOpcode.Actor_TransferRequest)]
	[ProtoContract]
	public partial class Actor_TransferRequest: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int MapIndex { get; set; }

	}

	[Message(OuterOpcode.Actor_TransferResponse)]
	[ProtoContract]
	public partial class Actor_TransferResponse: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(G2C_EnterMap))]
	[Message(OuterOpcode.C2G_EnterMap)]
	[ProtoContract]
	public partial class C2G_EnterMap: Object, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_EnterMap)]
	[ProtoContract]
	public partial class G2C_EnterMap: Object, IResponse
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public int Error { get; set; }

		[ProtoMember(3)]
		public string Message { get; set; }

// 自己unitId
		[ProtoMember(4)]
		public long MyId { get; set; }

	}

	[Message(OuterOpcode.MoveInfo)]
	[ProtoContract]
	public partial class MoveInfo: Object
	{
		[ProtoMember(1)]
		public List<float> X = new List<float>();

		[ProtoMember(2)]
		public List<float> Y = new List<float>();

		[ProtoMember(3)]
		public List<float> Z = new List<float>();

		[ProtoMember(4)]
		public float A { get; set; }

		[ProtoMember(5)]
		public float B { get; set; }

		[ProtoMember(6)]
		public float C { get; set; }

		[ProtoMember(7)]
		public float W { get; set; }

		[ProtoMember(8)]
		public int TurnSpeed { get; set; }

	}

	[Message(OuterOpcode.UnitInfo)]
	[ProtoContract]
	public partial class UnitInfo: Object
	{
		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public int ConfigId { get; set; }

		[ProtoMember(3)]
		public int Type { get; set; }

		[ProtoMember(4)]
		public float X { get; set; }

		[ProtoMember(5)]
		public float Y { get; set; }

		[ProtoMember(6)]
		public float Z { get; set; }

		[ProtoMember(7)]
		public float ForwardX { get; set; }

		[ProtoMember(8)]
		public float ForwardY { get; set; }

		[ProtoMember(9)]
		public float ForwardZ { get; set; }

		[ProtoMember(10)]
		public List<int> Ks = new List<int>();

		[ProtoMember(11)]
		public List<long> Vs = new List<long>();

		[ProtoMember(12)]
		public MoveInfo MoveInfo { get; set; }

	}

	[Message(OuterOpcode.M2C_CreateUnits)]
	[ProtoContract]
	public partial class M2C_CreateUnits: Object, IActorMessage
	{
		[ProtoMember(2)]
		public List<UnitInfo> Units = new List<UnitInfo>();

	}

	[Message(OuterOpcode.M2C_CreateMyUnit)]
	[ProtoContract]
	public partial class M2C_CreateMyUnit: Object, IActorMessage
	{
		[ProtoMember(1)]
		public UnitInfo Unit { get; set; }

	}

	[Message(OuterOpcode.M2C_StartSceneChange)]
	[ProtoContract]
	public partial class M2C_StartSceneChange: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long SceneInstanceId { get; set; }

		[ProtoMember(2)]
		public string SceneName { get; set; }

	}

	[Message(OuterOpcode.M2C_RemoveUnits)]
	[ProtoContract]
	public partial class M2C_RemoveUnits: Object, IActorMessage
	{
		[ProtoMember(2)]
		public List<long> Units = new List<long>();

	}

	[Message(OuterOpcode.C2M_PathfindingResult)]
	[ProtoContract]
	public partial class C2M_PathfindingResult: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public float X { get; set; }

		[ProtoMember(2)]
		public float Y { get; set; }

		[ProtoMember(3)]
		public float Z { get; set; }

	}

	[Message(OuterOpcode.C2M_Stop)]
	[ProtoContract]
	public partial class C2M_Stop: Object, IActorLocationMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_PathfindingResult)]
	[ProtoContract]
	public partial class M2C_PathfindingResult: Object, IActorMessage
	{
		[ProtoMember(1)]
		public long Id { get; set; }

		[ProtoMember(2)]
		public float X { get; set; }

		[ProtoMember(3)]
		public float Y { get; set; }

		[ProtoMember(4)]
		public float Z { get; set; }

		[ProtoMember(5)]
		public List<float> Xs = new List<float>();

		[ProtoMember(6)]
		public List<float> Ys = new List<float>();

		[ProtoMember(7)]
		public List<float> Zs = new List<float>();

	}

	[Message(OuterOpcode.M2C_Stop)]
	[ProtoContract]
	public partial class M2C_Stop: Object, IActorMessage
	{
		[ProtoMember(1)]
		public int Error { get; set; }

		[ProtoMember(2)]
		public long Id { get; set; }

		[ProtoMember(3)]
		public float X { get; set; }

		[ProtoMember(4)]
		public float Y { get; set; }

		[ProtoMember(5)]
		public float Z { get; set; }

		[ProtoMember(6)]
		public float A { get; set; }

		[ProtoMember(7)]
		public float B { get; set; }

		[ProtoMember(8)]
		public float C { get; set; }

		[ProtoMember(9)]
		public float W { get; set; }

	}

	[ResponseType(nameof(G2C_Ping))]
	[Message(OuterOpcode.C2G_Ping)]
	[ProtoContract]
	public partial class C2G_Ping: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.G2C_Ping)]
	[ProtoContract]
	public partial class G2C_Ping: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long Time { get; set; }

	}

	[Message(OuterOpcode.G2C_Test)]
	[ProtoContract]
	public partial class G2C_Test: Object, IMessage
	{
	}

	[ResponseType(nameof(M2C_Reload))]
	[Message(OuterOpcode.C2M_Reload)]
	[ProtoContract]
	public partial class C2M_Reload: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Account { get; set; }

		[ProtoMember(2)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.M2C_Reload)]
	[ProtoContract]
	public partial class M2C_Reload: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	[ResponseType(nameof(R2C_Login))]
	[Message(OuterOpcode.C2R_Login)]
	[ProtoContract]
	public partial class C2R_Login: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Account { get; set; }

		[ProtoMember(2)]
		public string Password { get; set; }

	}

	[Message(OuterOpcode.R2C_Login)]
	[ProtoContract]
	public partial class R2C_Login: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public string Address { get; set; }

		[ProtoMember(2)]
		public long Key { get; set; }

		[ProtoMember(3)]
		public long GateId { get; set; }

	}

	[ResponseType(nameof(G2C_LoginGate))]
	[Message(OuterOpcode.C2G_LoginGate)]
	[ProtoContract]
	public partial class C2G_LoginGate: Object, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long Key { get; set; }

		[ProtoMember(2)]
		public long GateId { get; set; }

	}

	[Message(OuterOpcode.G2C_LoginGate)]
	[ProtoContract]
	public partial class G2C_LoginGate: Object, IResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long PlayerId { get; set; }

	}

	[Message(OuterOpcode.G2C_TestHotfixMessage)]
	[ProtoContract]
	public partial class G2C_TestHotfixMessage: Object, IMessage
	{
		[ProtoMember(1)]
		public string Info { get; set; }

	}

	[ResponseType(nameof(M2C_TestRobotCase))]
	[Message(OuterOpcode.C2M_TestRobotCase)]
	[ProtoContract]
	public partial class C2M_TestRobotCase: Object, IActorLocationRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int N { get; set; }

	}

	[Message(OuterOpcode.M2C_TestRobotCase)]
	[ProtoContract]
	public partial class M2C_TestRobotCase: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public int N { get; set; }

	}

	[ResponseType(nameof(M2C_TransferMap))]
	[Message(OuterOpcode.C2M_TransferMap)]
	[ProtoContract]
	public partial class C2M_TransferMap: Object, IActorLocationRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[Message(OuterOpcode.M2C_TransferMap)]
	[ProtoContract]
	public partial class M2C_TransferMap: Object, IActorLocationResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

}
