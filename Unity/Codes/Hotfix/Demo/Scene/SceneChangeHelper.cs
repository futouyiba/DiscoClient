﻿namespace ET
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
            await Game.EventSystem.PublishAsync(new EventType.SceneChangeStart() {ZoneScene = zoneScene});

            // 等待CreateMyUnit的消息
            // WaitType.Wait_CreateMyUnit waitCreateMyUnit = await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_CreateMyUnit>();
            // M2C_CreateMyUnit m2CCreateMyUnit = waitCreateMyUnit.Message;
            // Unit unit = UnitFactory.Create(currentScene, m2CCreateMyUnit.Unit);
            // unitComponent.Add(unit);

            WaitType.Wait_all_sync waitAllSync = await zoneScene.GetComponent<ObjectWait>().Wait<WaitType.Wait_all_sync>();
            var all_sync = waitAllSync.Message;
            foreach (player p in all_sync.players)
            {
                await unitComponent.CreatePlayer(p);
            }

            await unitComponent.PopulateInit();

            zoneScene.RemoveComponent<AIComponent>();
            
            await Game.EventSystem.PublishAsync(new EventType.SceneChangeFinish() {ZoneScene = zoneScene, CurrentScene = currentScene});

            // 通知等待场景切换的协程
            zoneScene.GetComponent<ObjectWait>().Notify(new WaitType.Wait_SceneChangeFinish());
        }
    }
}