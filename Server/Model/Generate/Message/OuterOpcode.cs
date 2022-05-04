namespace ET
{
	/**
	 * enum Type 
{
    register_user_c2s = 10000;
    register_user_s2c = 10001;
    get_transfer_endpoint_c2s = 10002;
    get_transfer_endpoint_s2c = 10003;
    authenticate_c2s = 20000;
    authenticate_s2c = 20001;
    heartbeat_c2s = 20002;
    heartbeat_s2c = 20003;
    all_sync_s2c = 20004;
    player_enter_s2c = 20005;
    player_leave_s2c = 20006;
    action_req_c2s = 20007;
    action_req_s2c = 20008;
    action_syn_s2c = 20009;
}
	 */
	public static partial class OuterOpcode
	{
		public const ushort TMsg = 30005;
		public const ushort player = 30006;
		public const ushort register_user_c2s = 10000;
		public const ushort register_user_s2c = 10001;
		public const ushort get_transfer_endpoint_c2s = 10002;
		public const ushort get_transfer_endpoint_s2c = 10003;
		public const ushort authenticate_c2s = 20000;
		public const ushort authenticate_s2c = 20001;
		public const ushort heartbeat_c2s = 20002;
		public const ushort heartbeat_s2c = 20003;
		public const ushort all_sync_s2c = 20004;
		public const ushort player_enter_s2c = 20005;
		public const ushort player_leave_s2c = 20006;
		public const ushort action_req_c2s = 20007;  
		public const ushort action_req_s2c = 20008;
		public const ushort action_syn_s2c = 20009;
		/**
		 *     put_head_icon_c2s = 20010;
    put_head_icon_s2c = 20011;
    get_head_icons_c2s = 20012;
    get_head_icons_s2c = 20013;
    add_friend_c2s = 20014;
    add_friend_s2c = 20015;
    del_friend_c2s = 20016;
    del_friend_s2c = 20017;
		 */
		public const ushort put_head_icon_c2s = 20010;
		public const ushort put_head_icon_s2c = 20011;
		public const ushort get_head_icons_c2s = 20012;
		public const ushort get_head_icons_s2c = 20013;
		public const ushort add_friend_c2s = 20014;
		public const ushort add_friend_s2c = 20015;
		public const ushort del_friend_c2s = 20016;
		public const ushort del_friend_s2c = 20017;
		 public const ushort C2M_TestRequest = 10017;
		 public const ushort M2C_TestResponse = 10018;
		 public const ushort Actor_TransferRequest = 10019;
		 public const ushort Actor_TransferResponse = 10020;
		 public const ushort C2G_EnterMap = 10021;
		 public const ushort G2C_EnterMap = 10022;
		 public const ushort MoveInfo = 10023;
		 public const ushort UnitInfo = 10024;
		 public const ushort M2C_CreateUnits = 10025;
		 public const ushort M2C_CreateMyUnit = 10026;
		 public const ushort M2C_StartSceneChange = 10027;
		 public const ushort M2C_RemoveUnits = 10028;
		 public const ushort C2M_PathfindingResult = 10029;
		 public const ushort C2M_Stop = 10030;
		 public const ushort M2C_PathfindingResult = 10031;
		 public const ushort M2C_Stop = 10032;
		 public const ushort C2G_Ping = 10033;
		 public const ushort G2C_Ping = 10034;
		 public const ushort G2C_Test = 10035;
		 public const ushort C2M_Reload = 10036;
		 public const ushort M2C_Reload = 10037;
		 public const ushort C2R_Login = 10038;
		 public const ushort R2C_Login = 10039;
		 public const ushort C2G_LoginGate = 10040;
		 public const ushort G2C_LoginGate = 10041;
		 public const ushort G2C_TestHotfixMessage = 10042;
		 public const ushort C2M_TestRobotCase = 10043;
		 public const ushort M2C_TestRobotCase = 10044;
		 public const ushort C2M_TransferMap = 10045;
		 public const ushort M2C_TransferMap = 10046;
		 public const ushort house_cfg = 30007;
		 public const ushort house = 30008;
	}
}
