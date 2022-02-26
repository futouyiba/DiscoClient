namespace ET
{
    public class PlayerComponent: Entity, IAwake
    {
        public long MyId;
        public Session SelectorSession;
        public Session TransferSession;
        public string DeviceModel;
        public string DeviceProductId;
        public int UserId;//todo 在注册的时候写入持久化，在awake的时候从持久化里面读取
        public string LoginAddress = "82.157.8.127:8800"; // 热更新的时候可以在awake里面修改它。
    }
}