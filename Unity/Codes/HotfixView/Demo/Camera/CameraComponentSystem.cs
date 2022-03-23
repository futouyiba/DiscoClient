using System;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEditor.UI;
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
                self.AnimGotoState(CameraComponentSystem.AnimState.Sway);
            }
            if (Input.GetKey(KeyCode.Alpha2))
            {//down
                self.AnimGotoState(CameraComponentSystem.AnimState.Down);
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {//far
                self.AnimGotoState(CameraComponentSystem.AnimState.Far);
            }
            if (Input.GetKey(KeyCode.Alpha4))
            {//look at me
                try
                {

                    var unitComp = self.ZoneScene().CurrentScene().GetComponent<UnitComponent>();
                    var myUnitGo = unitComp.MyPlayerUnit().GetComponent<GameObjectComponent>().GameObject;
                    self.LookAtClose(myUnitGo, 3000).OnCompleted(() => Log.Info("look at ended"));

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
        public enum AnimState
        {
            Far,
            Down,
            Sway
        }

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
            StringBuilder sb = new StringBuilder();
            int errornum = 0;
            if (self.camera == null)
            {
                sb.Append("camera is null\n");
                errornum++;
            }

            if (self.initPos == null)
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


        public static async ETTask LookAtClose(this CameraComponent self, GameObject GO2Follow, long lookTime)
        {
            self.GOFollowing = GO2Follow;
            self.IsFollowing = true;
            await TimerComponent.Instance.WaitAsync(lookTime);

            self.IsFollowing = false;
            self.GOFollowing = null;
            //todo：之后整个动画
            self.camera.transform.position = self.initPos;
        }

        public static void AnimGotoState(this CameraComponent self, AnimState state)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Base Layer.");
            sb.Append(state.ToString());
            self.animator.Play(sb.ToString());
        }

        public static bool AnimCurrentState(this CameraComponent self, string name)
        {
            var currentStateInfo = self.animator.GetCurrentAnimatorStateInfo(0);
            return currentStateInfo.IsName(name);
        }
    }
}