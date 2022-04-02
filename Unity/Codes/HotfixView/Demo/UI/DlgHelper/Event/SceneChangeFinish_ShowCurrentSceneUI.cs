namespace ET
{
    
    public class SceneChangeFinish_ShowCurrentSceneUI: AEvent<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(EventType.SceneChangeFinish args)
        {
            args.ZoneScene.GetComponent<UIComponent>().HideWindow(WindowID.WindowID_Lobby);
            if (args.CurrentScene.Name == "Small_Club_Test")
            {
                await args.ZoneScene.CurrentScene().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Mian);
                // await TimerComponent.Instance.WaitAsync(15000);
                // await args.ZoneScene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_SelectFigure);
            }

            await ETTask.CompletedTask;
        }
    }
    
}