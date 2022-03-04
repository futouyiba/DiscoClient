using UnityEngine;

namespace ET
{
    public enum CharType
    {
        Player,
        Npc,
    }

    /// <summary>
    /// todo mvc拆分放在后面
    /// </summary>
    public class CharCompAwakeSystem: AwakeSystem<CharComp>
    {
        public override Void Awake(CharComp self)
        {
            if (self.CharType == CharType.Player)
            {
                Log.Info("Player Char awake! next step is to change color...");
                self.Parent.GetComponent<GameObjectComponent>().GameObject.GetComponent<SpriteRenderer>().Color = Color.Yellow;
            }
        }
    }
    
    [ObjectSystem]
    public class CharCompSystem:Compo
    
    public class CharComp:Entity, IAwake, IDestroy
    {
        public CharType CharType;
        public int PlayerId;

        protected CharComp(CharType charType, Int32 playerId)
        {
            this.CharType = charType;
            this.PlayerId = playerId;
        }

    }
}