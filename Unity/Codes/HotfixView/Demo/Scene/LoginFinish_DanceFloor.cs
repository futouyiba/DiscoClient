namespace ET{
    public class LoginFinish_DanceFloor:AEvent<EventType.LoginFinish>{
        protected override async ETTask Run(EventType.LoginFinish args){
            await SceneChangeHelper.SceneChangeTo(args.ZoneScene, "Map1", 65535);
            // await ETTask.CompletedTask;
        }
    }
}