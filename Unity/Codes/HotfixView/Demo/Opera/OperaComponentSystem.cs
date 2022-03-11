using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ET.Demo.Music;
using ET.Music;
using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class OperaComponentAwakeSystem : AwakeSystem<OperaComponent>
    {
        public override void Awake(OperaComponent self)
        {
            self.mapMask = LayerMask.GetMask("Map");
        }
    }

    [ObjectSystem]
    public class OperaComponentUpdateSystem : UpdateSystem<OperaComponent>
    {
        public override void Update(OperaComponent self)
        {
            self.Update().Coroutine();
        }
    }
    
    public static class OperaComponentSystem
    {
        public static async ETTask Update(this OperaComponent self)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Log.Info("mouse button down...");
                Ray ray = self.DiscoCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000, self.mapMask))
                {
                    Debug.DrawRay(ray.origin,ray.direction,Color.green, 5f);
                    Log.Info("draw debug line...");
                    self.ClickPoint = hit.point;
                    (self.move_action_req_c2s.float1, self.move_action_req_c2s.float2) = AfterUnitCreate_CreateUnitView.UnityPosToServerXY(hit.point);
                    action_req_s2c moveResp = (action_req_s2c)await self.ZoneScene().GetComponent<SessionComponent>().Session
                            .Call(self.move_action_req_c2s);
                    if (moveResp.Error != 0)
                    {
                        self.DomainScene().CurrentScene().GetComponent<UnitComponent>().MyPlayerUnit().GetComponent<MoveComponent>()
                                .MoveToAsync(new List<Vector3> { self.ClickPoint }, ConstValue.PlayerMoveSpeed).Coroutine();
                    }
                    // self.frameClickMap.X = self.ClickPoint.x;
                    // self.frameClickMap.Y = self.ClickPoint.y;
                    // self.frameClickMap.Z = self.ClickPoint.z;
                    // self.ZoneScene().GetComponent<SessionComponent>().Session.Send(self.frameClickMap);
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                CodeLoader.Instance.LoadLogic();
                Game.EventSystem.Add(CodeLoader.Instance.GetTypes());
                Game.EventSystem.Load();
                Log.Debug("hot reload success!");
            }
            
            if (Input.GetKeyDown(KeyCode.T))
            {
                C2M_TransferMap c2MTransferMap = new C2M_TransferMap();
                self.ZoneScene().GetComponent<SessionComponent>().Session.Call(c2MTransferMap).Coroutine();
            }

            // 上DJ
            if (Input.GetKeyDown(KeyCode.J))
            {
                var goDjResp = (action_req_s2c)await self.ZoneScene().GetComponent<SessionComponent>().Session
                        .Call(new action_req_c2s() { action_id = ConstValue.ACTION_ID_BECOME_DJ, int1 = 1, });
                
                if (goDjResp.Error == 0)
                {
                    GameObjectComponent gameObjectComponent = self.ZoneScene().GetComponent<UnitComponent>().MyPlayerUnit().GetComponent<GameObjectComponent>();
                    Transform myPlayerTransform = gameObjectComponent.GameObject.transform;
                    myPlayerTransform.position =
                            self.DjGO.transform.position;
                    gameObjectComponent.ChangeScale(2f);
                }
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                var cutSongResp = (action_req_s2c)await self.ZoneScene().GetComponent<SessionComponent>().Session
                        .Call(new action_req_c2s() { action_id = ConstValue.ACTION_ID_SWITCH_MUSIC, int1 = self.CurrentSongIndex + 1 });
                if (cutSongResp.Error == 0)
                {
                    self.ZoneScene().GetComponent<MusicComponent>().CutSong(cutSongResp.int1);
                }
            }

            await ETTask.CompletedTask;
        }
    }
}