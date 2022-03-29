using System;
using System.Text;
using UnityEngine;

namespace ET.Demo.Camera
{
    [ObjectSystem]
    public class CameraComponentAwakeSystem : AwakeSystem<CameraComponent>
    {
        public override void Awake(CameraComponent self)
        {
          
        }
    }

    [ObjectSystem]
    public class CameraComponentLateUpdateSystem : LateUpdateSystem<CameraComponent>
    {
        private static readonly Vector3 lookAtCamOffset = new Vector3(0 - 0.07f, 4.7f - 2.629f, -6.54f - (-14.184f));
        public override void LateUpdate(CameraComponent self)
        {
            //测试用输入
            if (Input.GetKey(KeyCode.Alpha1))
            {//sway
                self.AnimGotoState(CameraComponent.CameraAnimateState.Sway).OnCompleted(() =>
                {
                    Log.Info("sway completed");
                });
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {//down
                self.AnimGotoState(CameraComponent.CameraAnimateState.Down).OnCompleted(() =>
                {
                    Log.Info("down completed");
                });
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {//far
                self.AnimGotoState(CameraComponent.CameraAnimateState.Far).OnCompleted(() =>
                {
                    Log.Info("far completed");
                });
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {//look at me
                try
                {
                    self.AnimGotoState(CameraComponent.CameraAnimateState.FollowCharWithTime).OnCompleted(() =>
                    {
                        Log.Info("follow with time completed");
                    });
                }
                catch(Exception e)
                {
                    Log.Error(e);
                }
            }
            
            
            if (self.IsFollowing && self.GOFollowing != null)
            {
                self.camera.transform.position = self.GOFollowing.transform.position + lookAtCamOffset;
            }
            

        }
    }
    
    public static class CameraComponentSystem
    {
        
        /// <summary>
        /// 因为在awake中初始化会获得错误的摄像机
        /// 改为在SceneChangeFinish_SetGOs中触发这个初始化函数
        /// </summary>
        /// <param name="self"></param>
        public static void Init(this CameraComponent self)
        {
            self.camera= UnityEngine.Camera.main;
            self.initPos = self.camera.transform.position;
            self.animator = self.camera.gameObject.GetComponentInParent<Animator>();
            //初始化标记状态
            self.TaskCompleteClear();
            self.OnAnimateEnd().Coroutine();
            

            //logs for errors
            StringBuilder sb = new StringBuilder();
            int errornum = 0;
            if (self.camera == null)
            {
                sb.Append("camera is null\n");
                errornum++;
            }

            if (self.initPos == Vector3.zero)
            {
                sb.Append("camera pos error!\n");
                errornum++;
            }

            if (self.animator == null)
            {
                sb.Append("animator get error!\n");
                sb.Append($"camera go name is {self.camera.gameObject.name}");
                errornum++;
            }
            if(errornum>0) Log.Error(sb.ToString());
            // self.Awake();
        }


        // public static async ETTask LookAtClose(this CameraComponent self, GameObject GO2Follow, long lookTime)
        // {
        //     self.GOFollowing = GO2Follow;
        //     self.IsFollowing = true;
        //     // await TimerComponent.Instance.WaitAsync(lookTime);
        //
        //     self.IsFollowing = false;
        //     self.GOFollowing = null;
        //     //todo：之后整个动画
        //     self.camera.transform.position = self.initPos;
        //     self.CheckStill();
        // }

        
        public static async ETTask LookAtClose(this CameraComponent self, GameObject GO2Follow, ETTask<bool> task)
        {
            self.GOFollowing = GO2Follow;
            self.IsFollowing = true;
            await task;

            StopLookAtClose(self);
            // self.CheckStill();
        }

        public static void StopLookAtClose(this CameraComponent self)
        {
            self.IsFollowing = false;
            self.GOFollowing = null;
            //todo：之后整个动画
            self.camera.transform.position = self.initPos;
        }

        public static bool IsStateAPriorB(CameraComponent.CameraAnimateState stateA, CameraComponent.CameraAnimateState stateB)
        {
            int a = (int) stateA / 10;
            int b = (int) stateB / 10;
            if (a < b) return true;
            else return false;
        }
        
        
        
        /// <summary>
        /// 让animator播放某动画
        /// </summary>
        /// <param name="self"></param>
        /// <param name="state"></param>
        /// <returns>动画持续时间</returns>
        public static async ETTask AnimGotoState(this CameraComponent self, CameraComponent.CameraAnimateState state)
        {
            
            //检查现在是不是在进行动画
            if (self.IsTaskOngoing())
            {
                //检查优先级，小的能打断大的
                if (IsStateAPriorB(state, self.curState))
                {
                    var toCancel = self.OngoingCT;
                    self.OngoingCT = null;
                    toCancel?.Cancel();
                    self.OngoingTask = null;
                }
                else
                {//不能打断，跳过
                    return;
                }
            }

            //
            void AnimatorPlay()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Base Layer.");
                sb.Append(state.ToString());
                self.animator.Play(sb.ToString());
            }

            void AnimatorPlayStill()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Base Layer.Still");
                self.animator.Play(sb.ToString());
            }
            
            self.curState = state;
            int time = -1;
            switch (state)
            {
                case CameraComponent.CameraAnimateState.Down: 
                    time = 4000;
                    break;
                case CameraComponent.CameraAnimateState.Far: 
                    time = 4000;
                    break;
                case CameraComponent.CameraAnimateState.Sway: 
                    time = 20000;
                    break;
                case CameraComponent.CameraAnimateState.FollowCharWithTime:
                    time = 3000;
                    break;
                case CameraComponent.CameraAnimateState.FollowCharWithoutTime:
                    Log.Info($"follow char without time ,not setting timer");
                    break;
                default:
                    Log.Error($"state: {state.ToString()} not implemented");
                    break;
            }
            

            if (time > 0)
            {//有时间的行为
                self.OngoingCT = new ETCancellationToken();
                if (state != CameraComponent.CameraAnimateState.FollowCharWithTime)
                {
                    self.OngoingCT.Add(AnimatorPlayStill);
                    self.OngoingCT.Add(self.TaskCompleteClear);
                }
                else
                {
                    self.OngoingCT.Add(self.StopLookAtClose);
                    self.OngoingCT.Add(self.TaskCompleteClear);
                }

                self.OngoingTask = TimerComponent.Instance.WaitAsync(time, self.OngoingCT);
                self.OngoingTask.OnCompleted(self.TaskCompleteClear);
                if (state == CameraComponent.CameraAnimateState.FollowCharWithTime)
                {
                    var unitComp = self.ZoneScene().CurrentScene().GetComponent<UnitComponent>();
                    var myUnitGo = unitComp.MyPlayerUnit().GetComponent<GameObjectComponent>().GameObject;
                    await self.LookAtClose(myUnitGo, self.OngoingTask);
                }
                else
                {
                    AnimatorPlay();
                    await self.OngoingTask;
                }

            }
            else
            {//不计时行为
                if (state == CameraComponent.CameraAnimateState.FollowCharWithoutTime)
                {
                    var unitComp = self.ZoneScene().CurrentScene().GetComponent<UnitComponent>();
                    var myUnitGo = unitComp.MyPlayerUnit().GetComponent<GameObjectComponent>().GameObject;
                    self.OngoingCT = new ETCancellationToken();
                    self.OngoingTask = ETTask<bool>.Create();
                    // self.OngoingCT.Add(() =>
                    // {//这个事件取消就是完成
                    //     self.OngoingTask.SetResult(true);
                    // });

                    self.OngoingTask.OnCompleted(self.TaskCompleteClear);
                    await self.LookAtClose(myUnitGo, self.OngoingTask);
                }
                else
                {
                    Log.Error($"{state.ToString()} with no time set");
                }
            }

            await OnAnimateEnd(self);
        }

        public static void TaskCompleteClear(this CameraComponent self)
        {
            self.OngoingTask = null;
            self.OngoingCT = null;
            self.curState = CameraComponent.CameraAnimateState.None;
        }

        public static bool IsTaskOngoing(this CameraComponent self)
        {
            if (self.curState != CameraComponent.CameraAnimateState.None)
            {
                Log.Warning($"current state is {self.curState} but not none");
                return true;
            }

            if (self.OngoingTask != null)
            {
                Log.Warning($"current state is NONE, but onging task is not");
                return true;
            }

            if (self.OngoingCT != null)
            {
                Log.Warning($"current state is none, ongoing task exists, but no ct for it");
                return true;
            }

            return false;

        }

        // public static bool AnimCurrentState(this CameraComponent self, string name)
        // {
        //     var currentStateInfo = self.animator.GetCurrentAnimatorStateInfo(0);
        //     return currentStateInfo.IsName(name);
        // }


        // public static void OnAnimatorEnterStill(this CameraComponent self)
        // {
        //     self.IsAnimatorStill = true;
        //     self.CheckStill();
        // }
        
        // public static void OnAnimatorLeaveStill(this CameraComponent self)
        // {
        //     self.IsAnimatorStill = false;
        //     
        // }

        /// <summary>
        /// 每次摄像机停止跟随或者动画播完
        /// 检查一下是不是真的停下来了
        /// 如果真的停下来了，运行OnAnimateEnd
        /// </summary>
        /// <returns>是否成功安排了空闲任务</returns>
        // public static bool CheckStill(this CameraComponent self)
        // {
        //     //先检查是否已经有在执行的任务了
        //     if (self.enterStillTask?.IsCompleted == false)
        //     {
        //         return false;
        //     }
        //
        //     if (self.IsAnimatorStill && self.IsFollowing == false)
        //     {
        //         self.enterStillTask = self.OnAnimateEnd();
        //         return true;
        //     }
        //     else
        //     {
        //         return false;
        //     }
        // }
        
        
        /// <summary>
        /// 当动画结束，镜头也不再跟随时发生的事
        /// </summary>
        public static async ETTask OnAnimateEnd(this CameraComponent self)
        {
            //going Idle
            if (IsTaskOngoing(self))
            {
                Log.Warning($"ongong task {self.curState} not ended");
                await self.OngoingTask;
                return;
            }

            var stayTime = RandomHelper.RandomNumber(3000, 6000);
            self.curState = CameraComponent.CameraAnimateState.Idle;
            self.OngoingCT = new ETCancellationToken();
            self.OngoingCT.Add(self.TaskCompleteClear);
            self.OngoingTask = TimerComponent.Instance.WaitAsync(stayTime, self.OngoingCT);
            self.OngoingTask.OnCompleted(self.TaskCompleteClear);
            Log.Warning($"{Time.time}: setting idle task for {stayTime}");

            var awaiter = self.OngoingTask;        
            await awaiter;
            Log.Warning($"{Time.time}: idle task completed!,going for after animate");
            //然后随机进入sway或者Far
            var randRes = RandomHelper.RandomBool();
            if (randRes)
            {
                await self.AnimGotoState(CameraComponent.CameraAnimateState.Sway);
                // self.AnimGotoState(AnimState.Sway);
            }
            else
            {
                await self.AnimGotoState(CameraComponent.CameraAnimateState.Far);
            }


        }
    }
}