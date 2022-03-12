using DG.Tweening;
using ET.EventType;
using UnityEngine;

namespace ET
{
    public class BecomeDJ_ViewHandle:AEvent<EventType.BecomeDJ>
    {
        protected override async ETTask Run(BecomeDJ a)
        {
            var operaComp = a.Unit.ZoneScene().CurrentScene().GetComponent<OperaComponent>();
            var djPosGO = operaComp.DjGO;
            GameObjectComponent gameObjectComponent = a.Unit.GetComponent<GameObjectComponent>();
            var playerUnitTransform = gameObjectComponent.GameObject.transform;
            playerUnitTransform.position = djPosGO.transform.position;
            gameObjectComponent.ChangeScale(1.5f);
            //todo add some lighting and music aesthetic effects...
            await ETTask.CompletedTask;
        }
    }
    
    public class StartMove_ViewHandle:AEvent<EventType.MoveStart>
    {
        protected override async ETTask Run(MoveStart a)
        {
            var randSpeed = ConstValue.PlayerMoveSpeed * ((RandomHelper.RandFloat01() - 0.5f) * 0.2f + 1f); // up or down by 10 percent.
            Transform gameObjectTransform = a.Unit.GetComponent<GameObjectComponent>().GameObject.transform;
            Vector3 targetPos = AfterUnitCreate_CreateUnitView.ServerXYToUnityPos(a.x,a.y);
            var duration = (targetPos - gameObjectTransform.position).magnitude/randSpeed;
            gameObjectTransform.DOMove(targetPos, duration);
            await ETTask.CompletedTask;
        }
    }
    
    
}