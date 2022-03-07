namespace ET
{
    public static class SceneChangeHelper
    {
        // 场景切换协程
        public static async ETTask SceneChangeTo(Scene zoneScene, string sceneName, long sceneInstanceId)
        {
            zoneScene.RemoveComponent<AIComponent>();
            
            CurrentScenesComponent currentScenesComponent = zoneScene.GetComponent<CurrentScenesComponent>();
            currentScenesComponent.Scene?.Dispose(); // 删除之前的CurrentScene，创建新的
            Scene currentScene = SceneFactory.CreateCurrentScene(sceneInstanceId, zoneScene.Zone, sceneName, currentScenesComponent);
            UnitComponent unitComponent = currentScene.AddComponent<UnitComponent>();
            Log.Info("published scene change start...");
            // 可以订阅这个事件中创建Loading界面
            Game.EventSystem.Publish(new EventType.SceneChangeStart() {ZoneScene = zoneScene});

            // 等待CreateMyUnit的消息
            // WaitType.Wait_CreateMyUnit waitCreateMyUnit = await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_CreateMyUnit>();
            // M2C_CreateMyUnit m2CCreateMyUnit = waitCreateMyUnit.Message;
            // Unit unit = UnitFactory.Create(currentScene, m2CCreateMyUnit.Unit);
            // unitComponent.Add(unit);

            WaitType.Wait_all_sync waitAllSync = await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_all_sync>();
            var all_sync = waitAllSync.Message;
            foreach (player p in all_sync.players)
            {
                if (unitComponent.Get(p.player_id)!=null)
                {
                    // 已经有这个unit了，现在不会有，后续会有一些
                    continue;
                }
                var unit = UnitFactory.Create(currentScene, new UnitInfo()
                {
                    Type = (int)UnitType.Player,
                    ForwardX = RandomHelper.RandomBool()?1f:-1f,
                    ForwardY = 1,
                    ForwardZ = 1,
                    UnitId = p.player_id,
                    X = p.x,
                    Y = 0,
                    Z = p.y,
                });
                Log.Info("created unit:" + unit.Id);
            }

            zoneScene.RemoveComponent<AIComponent>();
            
            Game.EventSystem.Publish(new EventType.SceneChangeFinish() {ZoneScene = zoneScene, CurrentScene = currentScene});

            // 通知等待场景切换的协程
            zoneScene.GetComponent<ObjectWait>().Notify(new WaitType.Wait_SceneChangeFinish());
        }
    }
}