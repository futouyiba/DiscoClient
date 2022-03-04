namespace ET{
    public class LoginFinish_DanceFloor:AEvent<EventType.LoginFinish>{
        protected override async ETTask Run(EventType.LoginFinish args){
            args.ZoneScene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);

            await SceneChangeHelper.SceneChangeTo(args.ZoneScene, "Small Club_Test", 65535);
            // await ETTask.CompletedTask;
        }
    }
}