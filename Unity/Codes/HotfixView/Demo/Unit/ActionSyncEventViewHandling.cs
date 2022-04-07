using System;
using DG.Tweening;
using ET.Demo.Music;
using ET.EventType;
using ET.Music;
using UnityEngine;

namespace ET
{
    public class BecomeDJ_ViewHandle:AEvent<EventType.BecomeDJ>
    {
        protected override async ETTask Run(BecomeDJ a)
        {
            // data
            a.Unit.GetComponent<CharComp>().playerData.is_dj = a.SeatId;
            house houseStatusData = a.Unit.ZoneScene().CurrentScene().GetComponent<HouseComponent>().HouseStatusData;
            int playerID = a.Unit.GetComponent<CharComp>().playerData.player_id;
            houseStatusData.dj_playerids.Add(playerID);
            houseStatusData.on_dj_ids.Add(a.SeatId);
            
            // unity view
            var operaComp = a.Unit.ZoneScene().CurrentScene().GetComponent<OperaComponent>();
            var djPosGO = operaComp.DjGO; // todo later refactor this to another component.
            GameObjectComponent gameObjectComponent = a.Unit.GetComponent<GameObjectComponent>();
            var playerUnitTransform = gameObjectComponent.GameObject.transform;
            operaComp.DJParticleFloorGO.transform.position = playerUnitTransform.position;
            var position = djPosGO.transform.position;
            operaComp.DJParticleUpGO.transform.position = position + Vector3.up;
            operaComp.DJParticleFloorGO.GetComponent<ParticleSystem>().Play();
            operaComp.DJParticleUpGO.GetComponent<ParticleSystem>().Play();
            playerUnitTransform.position = position;
            gameObjectComponent.ChangeScale(1.5f);
            DOTween.Kill(playerUnitTransform);
            //todo add some lighting and music aesthetic effects...
            // ui show if this is myself
            if (a.Unit == a.Unit.ZoneScene().CurrentScene().GetComponent<UnitComponent>().MyPlayerUnit())
            {
                await a.Unit.ZoneScene().CurrentScene().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_DJ);
            }
            
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
            a.Unit.GetComponent<CharComp>().playerData.is_dj = 0;
            var houseStatusData = a.Unit.ZoneScene().CurrentScene().GetComponent<HouseComponent>().HouseStatusData;
            int playerID = a.Unit.GetComponent<CharComp>().playerData.player_id;

            int indexOf = houseStatusData.dj_playerids.IndexOf(playerID);
            houseStatusData.dj_playerids.RemoveAt(indexOf);
            houseStatusData.on_dj_ids.RemoveAt(indexOf);

            GameObjectComponent gameObjectComponent = a.Unit
                    .GetComponent<GameObjectComponent>();
            Transform playerTransform = gameObjectComponent.GameObject.transform;
            playerTransform.position =
                    AfterUnitCreate_CreateUnitView.ServerXYToUnityPos(a.Unit.GetComponent<CharComp>().playerData.x,
                        a.Unit.GetComponent<CharComp>().playerData.y);
            var operaComp = a.Unit.ZoneScene().CurrentScene().GetComponent<OperaComponent>();
            operaComp.DJParticleUpGO.transform.position = operaComp.DjGO.transform.position + Vector3.up;
            operaComp.DJParticleFloorGO.transform.position = playerTransform.position;
            operaComp.DJParticleFloorGO.GetComponent<ParticleSystem>().Play();
            operaComp.DJParticleUpGO.GetComponent<ParticleSystem>().Play();
            gameObjectComponent.ChangeScale(1f);
            
            if (a.Unit == a.Unit.ZoneScene().CurrentScene().GetComponent<UnitComponent>().MyPlayerUnit())
            {
                a.Unit.ZoneScene().CurrentScene().GetComponent<UIComponent>().HideWindow(WindowID.WindowID_DJ);
            }
            
            await ETTask.CompletedTask;
        }
    }
    
    public class StartMove_ViewHandle:AEvent<EventType.MoveStart>
    {
        protected override async ETTask Run(MoveStart a)
        {
            player playerData = a.Unit.GetComponent<CharComp>().playerData;
            
            if (playerData.is_dj > 0)
            {
                Log.Info(
                    $"trying to move but this unit is already dj. player data is:{playerData.player_id}, unit id:{a.Unit.Id}");
                return;
            }

            playerData.x = a.x;
            playerData.y = a.y;
            
            var randSpeed = ConstValue.PlayerMoveSpeed * ((RandomHelper.RandFloat01() - 0.5f) * 0.2f + 1f); // up or down by 10 percent.
            Transform gameObjectTransform = a.Unit.GetComponent<GameObjectComponent>().GameObject.transform;
            Vector3 targetPos = AfterUnitCreate_CreateUnitView.ServerXYToUnityPos(a.x,a.y);
            var duration = (targetPos - gameObjectTransform.position).magnitude/randSpeed;
            gameObjectTransform.DOMove(targetPos, duration).OnComplete(() => Game.EventSystem.Publish(new EventType.MoveStop() { Unit = a.Unit }));
            await ETTask.CompletedTask;
        }
    }
    
    public class ControlLighting_ViewHandle:AEvent<EventType.ControlLight>
    {
        protected override async ETTask Run(ControlLight a)
        {
            var onIds = a.ZoneScene.CurrentScene().GetComponent<HouseComponent>().HouseStatusData.on_lighting_ids;
            if (a.SwitchType == 1)
            {
                onIds.Add(a.LightId);
            }
            else
            {
                onIds.Remove(a.LightId);
            }
            //todo check how lights are controlled for now, and write hotfix code for it..
            
            await ETTask.CompletedTask;
        }
    }
    
    public class CutToMusic_ViewHandle:AEvent<EventType.CutToMusic>
    {
        protected override async ETTask Run(CutToMusic a)
        {
            a.ZoneScene.CurrentScene().GetComponent<HouseComponent>().HouseStatusData.music_id = a.MusicId;
            
            a.ZoneScene.CurrentScene().GetComponent<MusicComponent>().CutSong(a.MusicId);
            await ETTask.CompletedTask;
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
        protected override async ETTask Run(ChangeFigure a)
        {
            a.Unit.GetComponent<CharComp>().playerData.figure_id = a.FigureId;
            a.Unit.RemoveComponent<GameObjectComponent>();
            await Game.EventSystem.PublishAsync(new EventType.AfterUnitCreate() { Unit = a.Unit });
        }
    }
    
    public class ChangeName_ViewHandle:AEvent<EventType.ChangeName>
    {
        protected override async ETTask Run(ChangeName a)
        {
            a.Unit.GetComponent<CharComp>().playerData.player_name = a.Name;
            a.Unit.GetComponent<GameObjectComponent>().NameTMP.text = a.Name;
            if (a.Unit.GetComponent<CharComp>().playerData.player_id == PlayerPrefs.GetInt(LoginHelper.USER_ID))
            {
                a.Unit.ZoneScene().CurrentScene().GetComponent<UIComponent>().GetDlgLogic<DlgMian>().View.ENameTextText.SetText(a.Name);
            }
            await ETTask.CompletedTask;
        }
    }
    
    public class TakeSeat_ViewHandle:AEvent<EventType.TakeSeat>
    {
        protected override ETTask Run(TakeSeat a)
        {
            var houseStatus = a.Unit.ZoneScene().CurrentScene().GetComponent<HouseComponent>().HouseStatusData;
            a.Unit.GetComponent<CharComp>().playerData.seat = a.SeatId;
            int playerID = a.Unit.GetComponent<CharComp>().playerData.player_id;
            if (a.SeatId > 0)
            {
                houseStatus.seat_playerids.Add(playerID);
                houseStatus.on_seat_ids.Add(a.SeatId);                
            }
            else
            {
                int index = houseStatus.seat_playerids.IndexOf(playerID);
                houseStatus.seat_playerids.RemoveAt(index);
                houseStatus.on_seat_ids.RemoveAt(index);
            }
            
            // todo unity view handling
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