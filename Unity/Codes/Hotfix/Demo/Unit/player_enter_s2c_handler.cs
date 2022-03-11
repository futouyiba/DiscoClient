namespace ET
{
    [MessageHandler]
    public class player_enter_s2c_handler:AMHandler<player_enter_s2c>
    {
        protected override async ETTask Run(Session session, player_enter_s2c message)
        {
            Scene zoneScene = session.ZoneScene();
            UnitComponent unitComponent = zoneScene.GetComponent<UnitComponent>();
            Log.Info($"player entering.. zoneScene is {zoneScene}, id :{zoneScene.Id},unitcomp is{unitComponent},id:{unitComponent.Id}");
            await unitComponent.CreatePlayer(message.one_player);
            await ETTask.CompletedTask;
        }
    }
}