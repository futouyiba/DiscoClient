using ET.EventType;
using UnityEngine;

namespace ET
{
    public class SceneChangeFinish_SetGOs:AEvent<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(SceneChangeFinish ev)
        {
            var operaComp = ev.CurrentScene.GetComponent<OperaComponent>();
            if (operaComp == null)
            {
                Log.Info("Didn't find operaComponent");
                return;
            }
            operaComp.DiscoCamera = GameObject.FindWithTag("MainCamera");
            operaComp.DjGO = GameObject.FindWithTag("DJ");
            await ETTask.CompletedTask;
        }
    }
}