using System;

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
            self.SpriteGO.transform.localScale = self.OriScale * scale;
            // todo modify direction.
        }
    }
}