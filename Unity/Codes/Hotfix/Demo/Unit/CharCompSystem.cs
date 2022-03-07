using UnityEngine;

namespace ET
{
    /// <summary>
    /// todo mvc拆分放在后面
    /// </summary>
    [ObjectSystem]
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


    public static class CharCompSystem
    {
        public static void Update(CharComp self)
        {
            // todo let update system invoke this...
        }
    }
}