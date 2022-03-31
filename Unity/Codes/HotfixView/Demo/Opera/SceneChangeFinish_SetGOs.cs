using ET.Demo.Camera;
using ET.Demo.Light;
using ET.EventType;
using ET.Light;
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
            operaComp.DJParticleFloorGO = GameObject.Find("DJParticleFloor");
            operaComp.DJParticleUpGO = GameObject.Find("DJParticleUp");
            
            //初始化CameraComp
            var cameraComp = ev.ZoneScene.CurrentScene().GetComponent<CameraComponent>();
            cameraComp.Init();
            //初始化LightComp
            var LightComp = ev.ZoneScene.CurrentScene().GetComponent<LightComponent>();
            LightComp.Init();
            await ETTask.CompletedTask;        
        }
    }
}