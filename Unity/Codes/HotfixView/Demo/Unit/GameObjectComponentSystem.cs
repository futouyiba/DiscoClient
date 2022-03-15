using System;
using System.Threading.Tasks;
using DG.Tweening;
using ET.Module;
using ILRuntime.Runtime;
using UnityEngine;
using Random = System.Random;

namespace ET
{
    [ObjectSystem]
    public class GameObjectComponentDestroySystem: DestroySystem<GameObjectComponent>
    {
        public override void Destroy(GameObjectComponent self)
        {
            UnityEngine.Object.Destroy(self.GameObject);
        }
    }

    [ObjectSystem]
    public class GameObjectComponentAwakeSystem: AwakeSystem<GameObjectComponent>
    {
        public override void Awake(GameObjectComponent self)
        {
            self.CharComp = self.Parent.GetComponent<CharComp>(); //todo move it to after unit create instantiate view...
        }
    }

    public enum MoveType
    {
        StandStill = 0,
        MoveAround = 1,
    }

    public static class GameObjectCompSys
    {
        public static void ChangeScale(this GameObjectComponent self, float scale)
        {
            // self.SpriteGO.transform.localScale =
            // new Vector3(self.OriScale.x * scale * self.FowardDirection, self.OriScale.y * scale, self.OriScale.z * scale);
            self.GameObject.transform.localScale = Vector3.one * scale;
        }

        public static void ChangeMovingDirection(this GameObjectComponent self, float direction)
        {
            self.FowardDirection = direction;
            var oldScale = self.SpriteGO.transform.localScale;
            self.SpriteGO.transform.localScale =
                    new Vector3(oldScale.x * direction, oldScale.y, oldScale.z);
        }

        public static async ETTask StartRandomMovePeriodical(this GameObjectComponent self)
        {
            var waitTime = RandomHelper.RandFloat01() * 1000f;
            await TimerComponent.Instance.WaitAsync(waitTime.ToInt64());

            if (RandomHelper.RandFloat01()<0.2f)
            {
                var rand1 = RandomHelper.RandFloat01() * 2 - 1f;
                var rand2 = RandomHelper.RandFloat01() * 2 - 1f;
                float wanderRadius = ConstValue.WanderRadius;
                var randX = Mathf.Clamp01(wanderRadius * rand1 + self.CharComp.playerData.x);
                var randY = Mathf.Clamp01(self.CharComp.playerData.y + wanderRadius * rand2);
                var targetPos = AfterUnitCreate_CreateUnitView.ServerXYToUnityPos(randX, randY);
                var duration = (targetPos - self.GameObject.transform.position).magnitude / ConstValue.PlayerMoveSpeed;
                // var duration = (targetPos - self.GameObject.transform.position).magnitude / ConstValue.PlayerMoveSpeed *
                // (RandomHelper.RandFloat01() * 0.2f + 0.9f);
                self.GameObject.transform.DOMove(targetPos, duration).OnComplete(() =>
                {
                    self.StartRandomMovePeriodical().Coroutine();
                }); //todo no longer use 递归, so the exec stack would not be too thick.
            }
            else
            {
                self.StartRandomMovePeriodical().Coroutine();
            }
        }
    }
}