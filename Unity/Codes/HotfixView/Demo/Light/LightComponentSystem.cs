using ET.Demo.Music;
using ET.Light;
using ET.Music;
using UnityEngine;

namespace ET.Demo.Light
{
    public class LightComponentAwakeSystem: AwakeSystem<LightComponent>
    {
        public override void Awake(LightComponent self)
        {

        }
        
    }



    /// <summary>
    /// 管理所有效果灯的Component
    /// 每一个LightComponent对应一组灯
    /// </summary>
    public static class LightComponentSystem
    {

        /// <summary>
        /// awake太早，放在这里
        /// </summary>
        /// <param name="self"></param>
        public static void Init(this LightComponent self)
        {
            bool goRes = self.GetGo(1);
            if(!goRes) Log.Error($"get light go 1 failed");
            self.Off(1);

            var musicComp = self.ZoneScene().CurrentScene().GetComponent<MusicComponent>();
            musicComp.AddBeatDlg(self.TempBeatLightGroup);

        }
        /// <summary>
        /// 临时的灯光效果
        /// 每次beat都会改变第一组灯的开关状态
        /// </summary>
        /// <param name="self"></param>
        public static void TempBeatLightGroup(this LightComponent self)
        {
            var info = self.GroupInfoDict[1];
            if(info.isOn) self.Off(1);
            else if(!info.isOn) self.On(1);
        }

        /// <summary>
        /// 临时的开关动画
        /// 开一下然后关掉
        /// </summary>
        /// <param name="self"></param>
        // public static async ETTask TempLightOnOffAnimate(this LightComponent self, long duration)
        // {
        //     var info = self.GroupInfoDict[1];
        // }
        
        /// <summary>
        /// 从场景中拿到对应id的灯组
        /// 然后存入字典
        /// </summary>
        /// <param name="self"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GameObject GetGo(this LightComponent self, int id)
        {
            var GOFound = GameObject.FindGameObjectWithTag(string.Concat("LightGroup",id.ToString()));
            if (GOFound != null)
            {
                self.GoDict.Add(id,GOFound);
                //todo 更完善的信息初始化
                self.GroupInfoDict.Add(id,new LightGroupInfo(){behType = LightBehaviourType.Laser, isOn = true});
                return GOFound;
            }
            return null;
        }
        
        public static void On(this LightComponent self,int id)
        {
            var resGo=self.GoDict.TryGetValue(id, out GameObject go);
            if (resGo)
            {
                go.SetActive(true);
                self.GroupInfoDict.TryGetValue(id, out var Info);
                Info.isOn = true;
                Log.Info($"Setting lightgroup {id} on");
            }
            else
            {
                Log.Error($"Group {id} Light go does not exist!");
            }

        }

        public static void Off(this LightComponent self,int id)
        {
            var resGo=self.GoDict.TryGetValue(id, out GameObject go);
            if (resGo)
            {
                go.SetActive(false);
                self.GroupInfoDict.TryGetValue(id, out var Info);
                Info.isOn = false;
                Log.Info($"Setting lightgroup {id} off");
            }
            else
            {
                Log.Error($"Group {id} Light go does not exist!");
            }

        }

        public static void StopMoving(this LightComponent self)
        {
            Log.Error("stop moving not implemented");
        }
        
    }
}