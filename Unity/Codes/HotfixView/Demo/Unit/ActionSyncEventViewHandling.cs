using ET.EventType;

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
}