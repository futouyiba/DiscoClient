using System;
using UnityEngine;

namespace ET
{
    public static class CurrentScenesComponentSystem
    {
        [ObjectSystem]
        public class CurrentScenesComponentAwakeSystem: AwakeSystem<CurrentScenesComponent>
        {
            public override void Awake(CurrentScenesComponent self)
            {
            }
        }

        public static Scene CurrentScene(this Scene zoneScene)
        {
            Scene currentScene = zoneScene.GetComponent<CurrentScenesComponent>()?.Scene;
            Log.Info($"scene.current scene, param zoneScene is:{zoneScene}, currentScene is:{currentScene}");
            return currentScene;
        }
    }
}