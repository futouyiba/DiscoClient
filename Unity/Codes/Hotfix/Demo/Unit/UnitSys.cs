namespace ET
{
    [ObjectSystem]
    public class UnitDestroySystem:DestroySystem<Unit>
    {
        public override void Destroy(Unit self)
        {
            Game.EventSystem.PublishAsync(new EventType.AfterUnitRemove(){Unit = self}).Coroutine();
        }
    }
}