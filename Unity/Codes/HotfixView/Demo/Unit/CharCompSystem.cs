using UnityEngine;

namespace ET
{
    /// <summary>
    /// todo mvc拆分放在后面
    /// </summary>
    public class CharCompAwakeSystem: AwakeSystem<CharComp>
    {
        public override void Awake(CharComp self)
        {
            if (self.CharType == CharType.Player)
            {
                Log.Info("Player Char awake! next step is to change color...");
                self.Parent.GetComponent<GameObjectComponent>().GameObject.GetComponent<SpriteRenderer>().color = Color.yellow;;
            }
        }
    }


    [ObjectSystem]
    public static class CharCompSystem
    {
        
    }
}