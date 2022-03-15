using ET.EventType;

namespace ET
{
    public class AfterRemoveUnit_ViewHandling:AEvent<EventType.AfterUnitRemove>
    {
        protected override async ETTask Run(AfterUnitRemove a)
        {
            UnityEngine.Object.Destroy(a.Unit.GetComponent<GameObjectComponent>().GameObject);
            await ETTask.CompletedTask;
        }
    }
}