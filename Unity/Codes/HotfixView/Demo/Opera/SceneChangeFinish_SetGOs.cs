using ET.Demo.Camera;
using ET.Demo.Light;
using ET.Demo.Stage;
using ET.EventType;
using ET.Light;
using ET.Stage;
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

            var curScene = ev.ZoneScene.CurrentScene();
            //初始化CameraComp
            var cameraComp = curScene.GetComponent<CameraComponent>();
            cameraComp.Init();
            //初始化LightComp
            var LightComp = curScene.GetComponent<LightComponent>();
            LightComp.Init();
            //初始化ParicleComp
            var ParticleComp = curScene.GetComponent<ParticleComponent>();
            ParticleComp.Init();
            
            await ETTask.CompletedTask;        
        }
    }
}