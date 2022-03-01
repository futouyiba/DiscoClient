namespace ET{
    public class LoginFinish_CreateDemoUI:AEvent<EventType.LoginFinish>{
        protected override async ETTask Run(EventType.LoginFinish args){
            await UIHelper.Create(args.ZoneScene,UIType.UIDemo,UILayer.Mid);
        }
    }
}