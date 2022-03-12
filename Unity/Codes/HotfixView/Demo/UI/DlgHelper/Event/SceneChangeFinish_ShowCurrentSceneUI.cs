namespace ET
{
    
    public class SceneChangeFinish_ShowCurrentSceneUI: AEvent<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(EventType.SceneChangeFinish args)
        {
            if (args.CurrentScene.Name == "Small_Club_Test")
            {
                await args.ZoneScene.CurrentScene().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Mian);
            }
            
            args.ZoneScene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Lobby);
            await ETTask.CompletedTask;
        }
    }
    
}