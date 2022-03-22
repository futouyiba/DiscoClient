// namespace ET
// {
//     
//     public class SceneChangeFinish_PopulateInit: AEvent<EventType.SceneChangeFinish>
//     {
//         protected override async ETTask Run(EventType.SceneChangeFinish args)
//         {
//             args.ZoneScene.CurrentScene().GetComponent<UnitComponent>().PopulateInit().Coroutine();
//             await ETTask.CompletedTask;
//         }
//     }
// }