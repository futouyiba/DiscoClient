using ET.EventType;

namespace ET.Demo.Camera
{
    public class CameraLookAtUnit_MoveStart:AEvent<EventType.MoveStart>
    {
        protected override async ETTask Run(MoveStart arg)
        {
            //如果是我，开始跟着走
            var unitComp = arg.Unit.ZoneScene().CurrentScene().GetComponent<UnitComponent>();
            var myUnit = unitComp.MyPlayerUnit();
            if (arg.Unit.Id == myUnit.Id)
            {
                // var myUnitGo = myUnit.GetComponent<GameObjectComponent>().GameObject;
                var camComp = arg.Unit.ZoneScene().CurrentScene().GetComponent<CameraComponent>();
                await camComp.AnimGotoState(CameraComponent.CameraAnimateState.FollowCharWithoutTime);
                // //让camera进入跟随状态
                // var myUnitGo = myUnit.GetComponent<GameObjectComponent>().GameObject;
                // var camComp = arg.Unit.ZoneScene().CurrentScene().GetComponent<CameraComponent>();
                // var moveTask = ETTask.Create();
                // camComp.followingTask = moveTask;
                // camComp.LookAtClose(myUnitGo, moveTask);
            }
            await ETTask.CompletedTask;
        }   
        
    }
    
    public class CameraLookAtUnit_MoveStop:AEvent<EventType.MoveStop>
    {
        protected override async ETTask Run(MoveStop arg)
        {
            // Log.Warning($"{arg.Unit.Id} Move stopped");
            //如果是我，停止跟随
            //todo：也许停一下再停止跟随？但是这样就要面对还在等待时又来了新的指令，把跟随续上的问题
            var unitComp = arg.Unit.ZoneScene().CurrentScene().GetComponent<UnitComponent>();
            var myUnit = unitComp.MyPlayerUnit();
            if (arg.Unit.Id == myUnit.Id)
            {
                var camComp = arg.Unit.ZoneScene().CurrentScene().GetComponent<CameraComponent>();
                if (camComp.OngoingTask != null && camComp.curState == CameraComponent.CameraAnimateState.FollowCharWithoutTime)
                {
                    // Log.Warning("stopping camera follow char");
                    camComp.OngoingCT?.Cancel();
                    //cancel会让task setresult
                    //setresult之后，lookClose（）会结束等待并让镜头不再跟随
                }
            }
            
            await ETTask.CompletedTask;

        }
        
        
    }
    

    
}