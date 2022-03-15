namespace ET
{
    [ObjectSystem]
    public class UnitDestroySystem:DestroySystem<Unit>
    {
        public override void Destroy(Unit self)
        {
            // for now we don't publish this event because game object component already destroy the game object on view.
            // Game.EventSystem.PublishAsync(new EventType.AfterUnitRemove(){Unit = self}).Coroutine();
        }
    }
}