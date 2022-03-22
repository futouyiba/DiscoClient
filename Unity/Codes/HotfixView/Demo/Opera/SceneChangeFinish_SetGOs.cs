using ET.Demo.Camera;
using ET.EventType;
using UnityEngine;

namespace ET
{
    public class SceneChangeFinish_SetGOs:AEvent<EventType.SceneChangeHaveArtMissingChars>
    {
        protected override async ETTask Run(SceneChangeHaveArtMissingChars ev)
        {
            var operaComp = ev.ZoneScene.CurrentScene().GetComponent<OperaComponent>();
            if (operaComp == null)
            {
                Log.Info("Didn't find operaComponent");
                return;
            }
            operaComp.DiscoCamera = GameObject.FindWithTag("MainCamera");
            operaComp.DjGO = GameObject.FindWithTag("DJ");
            
            //初始化CameraComp
            var cameraComp = ev.ZoneScene.CurrentScene().GetComponent<CameraComponent>();
            cameraComp.InitComp();
            await ETTask.CompletedTask;        
        }
    }
}