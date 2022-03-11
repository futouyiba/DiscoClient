using System;
using UnityEngine;

namespace ET
{
    public static class GameObjectComponentSystem
    {
        [ObjectSystem]
        public class DestroySystem: DestroySystem<GameObjectComponent>
        {
            public override void Destroy(GameObjectComponent self)
            {
                UnityEngine.Object.Destroy(self.GameObject);
            }
        }
    }

    public static class GameObjectCompSys
    {
        public static void ChangeScale(this GameObjectComponent self, float scale)
        {
            // self.SpriteGO.transform.localScale =
                    // new Vector3(self.OriScale.x * scale * self.FowardDirection, self.OriScale.y * scale, self.OriScale.z * scale);
                    self.GameObject.transform.localScale = Vector3.one * 2;
        }
    }
}