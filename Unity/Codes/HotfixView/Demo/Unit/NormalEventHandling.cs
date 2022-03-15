using ET.EventType;

namespace ET
{
    /// <summary>
    /// 两种情况下会用到：
    /// · 有玩家退出
    /// · 有玩家进入，从而引发几个npc的删除
    /// </summary>
    public class AfterRemoveUnit_ViewHandling:AEvent<EventType.AfterUnitRemove>
    {
        protected override async ETTask Run(AfterUnitRemove a)
        {
            UnityEngine.Object.Destroy(a.Unit.GetComponent<GameObjectComponent>().GameObject);
            await ETTask.CompletedTask;
        }
    }
}