namespace ET
{
    public class PingComponent: Entity, IAwake, IDestroy
    {
        [NoMemoryCheck]
        public heartbeat_c2s heartbeatC2S = new heartbeat_c2s();

        public long Ping; //延迟值
    }
}