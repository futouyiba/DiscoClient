using UnityEngine;
namespace ET
{
    public class SceneChangeStart_AddComponent: AEvent<EventType.SceneChangeStart>
    {
        protected override async ETTask Run(EventType.SceneChangeStart args)
        {
            Log.Info("SceneChangeStart_AddComponent event class ran...");
            
            Scene currentScene = args.ZoneScene.CurrentScene();
            
            
            // 加载场景资源
            //await ResourcesComponent.Instance.LoadBundleAsync($"{currentScene.Name}.unity3d");
            //await AddressableComponent.Instance.LoadSceneByPathAsync($"{currentScene.Name}.unity3d");
            // 切换到map场景

            SceneChangeComponent sceneChangeComponent = null;
            try
            {
                // sceneChangeComponent = Game.Scene.AddComponent<SceneChangeComponent>();
                sceneChangeComponent = currentScene.AddComponent<SceneChangeComponent>();
                {
                    var SCTask= sceneChangeComponent.ChangeSceneAsync(currentScene.Name);
                    // sceneChangeComponent.UpdateProcess();
                    await SCTask;
                }
            }
            finally
            {
                sceneChangeComponent?.Dispose();
            }

            //await UIHelper.Remove(currentScene, UIType.UILogin);

        }
    }
}