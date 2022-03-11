namespace ET
{
    public class AfterCreateCurrentScene_AddComponent: AEvent<EventType.AfterCreateCurrentScene>
    {
        protected override async ETTask Run(EventType.AfterCreateCurrentScene args)
        {
            Scene currentScene = args.CurrentScene;
            currentScene.AddComponent<ResourcesLoaderComponent>();
            currentScene.AddComponent<UnitComponent>();
            currentScene.AddComponent<UIComponent>().HideWindow(WindowID.WindowID_Login);
            currentScene.AddComponent<OperaComponent>();
            Log.Info($"operacomponent added... currentscene:{currentScene},id:{currentScene.Id}");
            await ETTask.CompletedTask;
        }
    }
}