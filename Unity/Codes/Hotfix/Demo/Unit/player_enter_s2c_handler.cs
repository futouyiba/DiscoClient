namespace ET
{
    [MessageHandler]
    public class player_enter_s2c_handler:AMHandler<player_enter_s2c>
    {
        protected override ETTask Run(Session session, player_enter_s2c message)
        {
            await session.ZoneScene().GetComponent<UnitComponent>().CreatePlayer(message.one_player);
            await ETTask.CompletedTask;
        }
    }
}