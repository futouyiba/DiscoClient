﻿namespace ET
{
    
    public class SceneChangeFinish_PopulateInit: AEvent<EventType.SceneChangeFinish>
    {
        protected override async ETTask Run(EventType.SceneChangeFinish args)
        {
            await args.CurrentScene.GetComponent<UnitComponent>().PopulateInit();
            await ETTask.CompletedTask;
        }
    }
    
}