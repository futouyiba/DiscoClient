namespace ET
{
    /// <summary>
    /// todo mvc拆分放在后面
    /// </summary>
    [ObjectSystem]
    public class CharCompAwakeSystem: AwakeSystem<CharComp, player>
    {
        /// <summary>
        /// 用于player的初始化。隐式的表示这是个player
        /// </summary>
        /// <param name="self"></param>
        /// <param name="player"></param>
        public override void Awake(CharComp self, player player)
        {
            self.CharType = CharType.Player;
            self.playerData = player;
                Log.Info("Player awake! player:"+ player);
        }
    }

    [ObjectSystem]
    public class CharCompNpcAwakeSystem: AwakeSystem<CharComp>
    {
        /// <summary>
        /// npc初始化，不带playerData。隐式的表示这是个npc
        /// </summary>
        /// <param name="self"></param>
        public override void Awake(CharComp self)
        {
            self.CharType = CharType.Npc;
        }
    }
    public static class CharCompSystem
    {
        public static void Update(CharComp self)
        {
            // todo let update system invoke this...
        }
    }
}