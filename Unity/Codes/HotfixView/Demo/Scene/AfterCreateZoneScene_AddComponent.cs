using UnityEngine.SceneManagement;

namespace ET
{
    public class AfterCreateZoneScene_AddComponent: AEvent<EventType.AfterCreateZoneScene>
    {
        protected override async ETTask Run(EventType.AfterCreateZoneScene args)
        {
            Scene zoneScene = args.ZoneScene;
            zoneScene.AddComponent<UIComponent>();
            zoneScene.AddComponent<UIPathComponent>();
            zoneScene.AddComponent<UIEventComponent>();
            zoneScene.AddComponent<RedDotComponent>();
            zoneScene.AddComponent<ResourcesLoaderComponent>();
            var scComp = zoneScene.AddComponent<SceneChangeComponent>();
            // await SceneChangeHelper.SceneChangeTo(zoneScene, "Login_3D", 65534);
            await scComp.ChangeSceneAsync("Login_3D");
            // var loadOp = SceneManager.LoadSceneAsync("Login_3D");

            await zoneScene.GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_Login);
            await ETTask.CompletedTask;
        }
    }
}