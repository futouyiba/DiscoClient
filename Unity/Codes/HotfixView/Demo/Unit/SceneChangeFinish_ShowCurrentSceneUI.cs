using ET.Demo.Music;
using ET.Music;
using ET.Sounds;

namespace ET
{
    
    public class SceneChangeFinish_PopulateInit: AEvent<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(EventType.SceneChangeFinish args)
        {
            args.ZoneScene.CurrentScene().GetComponent<UnitComponent>().PopulateInit().Coroutine();
            await ETTask.CompletedTask;
        }
    }

    public class SceneChangeFinish_MusicInit: AEvent<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(EventType.SceneChangeFinish args)
        {
            var musicComp=args.ZoneScene.CurrentScene().GetComponent<SoundComponent>().GetComponent<MusicComponent>();
            musicComp.CreateGO();
            musicComp.PlaySong(0);
            Log.Info("Create music comp successed!");
            await ETTask.CompletedTask;
        }
    }
}