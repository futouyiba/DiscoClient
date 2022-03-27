namespace ET
{
    [MessageHandler]
    public class player_leave_s2c_Handler:AMHandler<player_leave_s2c>
    {
        protected override async ETTask Run(Session session, player_leave_s2c message)
        {
            var unitComp = session.ZoneScene().CurrentScene().GetComponent<UnitComponent>();
            if (unitComp.PlayerUnits.ContainsKey(message.player_id))
            {
                unitComp.PlayerUnits[message.player_id].Dispose();
                unitComp.PlayerUnits.Remove(message.player_id);
            }

            await ETTask.CompletedTask;
        }
    }
}