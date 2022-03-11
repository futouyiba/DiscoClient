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

        public const float PlayerMoveSpeed = 4f;

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

        /**        %% 动作id定义
        -define(ACTION_ID_BECOME_DJ, 1). %上dj
        -define(ACTION_ID_MOVE_TO, 2). % 移动
        -define(ACTION_ID_CONTROL_LIGHTING, 3). % 控制一个test灯
        -define(ACTION_ID_SWITCH_MUSIC, 4). % 切歌
        -define(ACTION_ID_BECOME_BIGGER, 5). % 变大
        -define(ACTION_ID_CHANGE_FIGURE, 6). % 改变形象 
        */
        public const int ACTION_ID_BECOME_DJ = 1;
        public const int ACTION_ID_MOVE_TO = 2;
        public const int ACTION_ID_CONTROL_LIGHTING = 3;
        public const int ACTION_ID_SWITCH_MUSIC = 4;
        public const int ACTION_ID_BECOME_BIGGER = 5;
        public const int ACTION_ID_CHANGE_FIGURE = 6;
        
    }
}