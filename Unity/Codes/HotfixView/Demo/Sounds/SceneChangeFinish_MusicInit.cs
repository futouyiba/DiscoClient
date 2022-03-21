using ET.Demo.Music;
using ET.Demo.Sounds;
using ET.Music;
using ET.Sounds;

namespace ET
{
    
    public class SceneChangeFinish_MusicInit: AEvent<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(EventType.SceneChangeFinish args)
        {
            var musicComp=args.ZoneScene.CurrentScene().GetComponent<SoundComponent>().GetComponent<MusicComponent>();
            var go=musicComp.CreateGO();
            musicComp.PlaySong(0);
            Log.Info("Create music comp successed!");
            await ETTask.CompletedTask;
        }
    }

    public class SceneChangeFinish_AttachBeatScripts: AEvent<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(EventType.SceneChangeFinish args)
        {
            var musicComp=args.ZoneScene.CurrentScene().GetComponent<SoundComponent>().GetComponent<MusicComponent>();
            var scriptsAttached=SoundHelper.AttachAllUnityComponents(musicComp);
            Log.Info($"Attached {scriptsAttached} unity BEAT components");
            await ETTask.CompletedTask;
        }
    }
}