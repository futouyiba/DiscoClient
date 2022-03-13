using UnityEngine;
namespace ET{
    public class LoginFinish_DanceFloor:AEvent<EventType.LoginFinish>{
        protected override async ETTask Run(EventType.LoginFinish args){

            await SceneChangeHelper.SceneChangeTo(args.ZoneScene, "Small_Club_Test", 65535);
            args.ZoneScene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
            // await ETTask.CompletedTask;
        }
    }
}