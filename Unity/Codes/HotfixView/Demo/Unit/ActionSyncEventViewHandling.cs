using DG.Tweening;
using ET.EventType;
using UnityEngine;

namespace ET
{
    public class BecomeDJ_ViewHandle:AEvent<EventType.BecomeDJ>
    {
        protected override async ETTask Run(BecomeDJ a)
        {
            var operaComp = a.Unit.ZoneScene().CurrentScene().GetComponent<OperaComponent>();
            var djPosGO = operaComp.DjGO;
            GameObjectComponent gameObjectComponent = a.Unit.GetComponent<GameObjectComponent>();
            var playerUnitTransform = gameObjectComponent.GameObject.transform;
            playerUnitTransform.position = djPosGO.transform.position;
            gameObjectComponent.ChangeScale(1.5f);
            //todo add some lighting and music aesthetic effects...
            await ETTask.CompletedTask;
        }
    }
    
    public class LeaveDJ_ViewHandle:AEvent<EventType.LeaveDJ>
    {
        /// <summary>
        /// todo 搞个动画，依次await
        /// </summary>
        /// <param name="a"></param>
        protected override async ETTask Run(LeaveDJ a)
        {
            GameObjectComponent gameObjectComponent = a.Unit
                    .GetComponent<GameObjectComponent>();
            Transform playerTransform = gameObjectComponent.GameObject.transform;
            playerTransform.position =
                    AfterUnitCreate_CreateUnitView.ServerXYToUnityPos(a.Unit.GetComponent<CharComp>().playerData.x,
                        a.Unit.GetComponent<CharComp>().playerData.y);
            gameObjectComponent.ChangeScale(1f);
            await ETTask.CompletedTask;
        }
    }
    
    public class StartMove_ViewHandle:AEvent<EventType.MoveStart>
    {
        protected override async ETTask Run(MoveStart a)
        {
            var randSpeed = ConstValue.PlayerMoveSpeed * ((RandomHelper.RandFloat01() - 0.5f) * 0.2f + 1f); // up or down by 10 percent.
            Transform gameObjectTransform = a.Unit.GetComponent<GameObjectComponent>().GameObject.transform;
            Vector3 targetPos = AfterUnitCreate_CreateUnitView.ServerXYToUnityPos(a.x,a.y);
            var duration = (targetPos - gameObjectTransform.position).magnitude/randSpeed;
            gameObjectTransform.DOMove(targetPos, duration);
            await ETTask.CompletedTask;
        }
    }
    
    public class ControlLighting_ViewHandle:AEvent<EventType.ControlLight>
    {
        protected override async ETTask Run(ControlLight a)
        {
            //todo check how lights are controlled for now, and write hotfix code for it..
            
            await ETTask.CompletedTask;
        }
    }
    
    public class CutToMusic_ViewHandle:AEvent<EventType.CutToMusic>
    {
        protected override ETTask Run(CutToMusic a)
        {
            throw new System.NotImplementedException();
        }
    }

    public class GrowBig_ViewHandle:AEvent<EventType.GrowBig>
    {
        protected override async ETTask Run(GrowBig a)
        {
            // start tween DOScale todo
            GameObjectComponent gameObjectComponent = a.Unit.GetComponent<GameObjectComponent>();
            gameObjectComponent.ChangeScale(1.5f);
            gameObjectComponent.GameObject.transform.DOShakeScale(1.5f, 1f);
            
            // make camera focused on this gameObject
            
            // play light effects
            await ETTask.CompletedTask;
        }
    }
    
    public class ChangeFigure_ViewHandle:AEvent<EventType.ChangeFigure>
    {
        protected override ETTask Run(ChangeFigure a)
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class TakeSeat_ViewHandle:AEvent<EventType.TakeSeat>
    {
        protected override ETTask Run(TakeSeat a)
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class ShoutSlogan_ViewHandle:AEvent<EventType.ShoutSlogan>
    {
        protected override ETTask Run(ShoutSlogan a)
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class Chat_ViewHandle:AEvent<EventType.Chat>
    {
        protected override ETTask Run(Chat a)
        {
            // add chat bubble
            
            // add chat history within the ui panel
            throw new System.NotImplementedException();
        }
    }
}