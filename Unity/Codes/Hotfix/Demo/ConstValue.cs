namespace ET
{
    public static class ConstValue
    {
        public const string LoginAddress = "127.0.0.1:10002";
        public const string SelectorAddress = "82.157.8.127:8800";
        /// <summary>
        /// actually it's x gap AND y gap at the same time.
        /// </summary>
        public const float WanderRadius = 0.1f;

        public const float PlayerMoveSpeed = 1f;

        public const int PopulateGoalNum = 500;
        /// <summary>
        /// at start we don't use it, only use dynamic rubberband mechanic.
        /// </summary>
        public const int PopulateUpValue = 550;
        public const int PopulateDownValue = 450;

        /// <summary>
        /// 考虑每进来一个玩家，有一定的几率去除n个npc。
        /// </summary>
        public const float RubberbandChance = 0.2f;
        public const int RubberbandStrength = 4;

        /**
         * %% 动作id定义
-define(ACTION_ID_BECOME_DJ, 1). %上dj
-define(ACTION_ID_MOVE_TO, 2). % 移动
-define(ACTION_ID_CONTROL_LIGHTING, 3). % 控制一个test灯
-define(ACTION_ID_SWITCH_MUSIC, 4). % 切歌
-define(ACTION_ID_BECOME_BIGGER, 5). % 变大
-define(ACTION_ID_CHANGE_FIGURE, 6). % 改变形象
-define(ACTION_ID_TAKE_SEAT, 7). % 上卡座
-define(ACTION_ID_SHOUT_SLOGAN, 8). % 一起喊口号
-define(ACTION_ID_CHAT, 9). % 聊天
-define(ACTION_ID_CHANGE_NAME, 10). % 改名
        https://i1c127izva.feishu.cn/docs/doccnJj1BcR84qI36LvLu0epYP0
        */
        public const int ACTION_ID_BECOME_DJ = 1;
        public const int ACTION_ID_MOVE_TO = 2;
        public const int ACTION_ID_CONTROL_LIGHTING = 3;
        public const int ACTION_ID_SWITCH_MUSIC = 4;
        public const int ACTION_ID_BECOME_BIGGER = 5;
        public const int ACTION_ID_CHANGE_FIGURE = 6;
        public const int ACTION_ID_TAKE_SEAT = 7;
        public const int ACTION_ID_SHOUT_SLOGAN = 8;
        public const int ACTION_ID_CHAT = 9;
        public const int ACTION_ID_CHANGE_NAME = 10;

        /**
         * %% 控灯选项
-define(LIGHTING_TURN_OFF, 0).
-define(LIGHTING_TURN_ON, 1).
-define(LIGHTING_FLIP_FLOP, 2).
         */
        public const int LIGHTING_TURN_OFF = 0;
        public const int LIGHTING_TURN_ON = 1;
        public const int LIGHTING_FLIP_FLOP = 2;
        
        //         -define(ACTION_SRC_TURN_OFF_DJ_4_OFFLINE_TIMEOUT, 1).
        //         -define(ACTION_SRC_TURN_OFF_DJ_4_KICKED_BY_OTHER, 2).
        //         %% 下卡座
        // -define(ACTION_SRC_TAKE_OFF_SEAT_4_OFFLINE_TIMEOUT, 1).
        //         -define(ACTION_SRC_TAKE_OFF_SEAT_4_KICKED_BY_OTHER, 2).
        public const int ACTION_SRC_TURN_OFF_DJ_4_OFFLINE_TIMEOUT = 1;
        public const int ACTION_SRC_TURN_OFF_DJ_4_KICKED_BY_OTHER = 2;
        public const int ACTION_SRC_TAKE_OFF_SEAT_4_OFFLINE_TIMEOUT = 1;
        public const int ACTION_SRC_TAKE_OFF_SEAT_4_KICKED_BY_OTHER = 2;
        
        
        //         % 特定的几个错误码定义 todo define constants...
        // -define(ERRNO_IP_BLOCKED, -1000). % ip受限
        // -define(ERRNO_UNKNOWN_PROTO, -999). % 协议不支持
        // -define(ERRNO_MISSING_PARAM, -998). % 参数不全
        // -define(ERRNO_WRONG_PARAM, -997). % 参数错误
        // -define(ERRNO_VERIFY_FAILED, -996). % 校验失败
        // -define(ERRNO_EXCEPTION, -995). % 异常抛出
        // -define(ERRNO_LOGIC_PROBLEM, -994). % 逻辑问题
    }
}