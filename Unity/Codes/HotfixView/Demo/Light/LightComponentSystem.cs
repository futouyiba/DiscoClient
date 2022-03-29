using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
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
            self.AddLightGroup(1, new LightGroupInfo(LightBehaviourType.Cookie, true));
            self.AddLightGroup(2, new LightGroupInfo(LightBehaviourType.Laser, true));
            self.AddLightGroup(3, new LightGroupInfo(LightBehaviourType.SpotStop, true));
            self.AddLightGroup(4, new LightGroupInfo(LightBehaviourType.Strob, false));
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
            self.OnOff(1, !info.isOn);
            self.OnOff(2, !info.isOn);

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
        
    

        public static GameObject AddLightGroup(this LightComponent self, int id, LightGroupInfo info)
        {
            var GoFound = GameObject.FindGameObjectWithTag(string.Concat("LightGroup",id.ToString()));
            if (GoFound!=null)
            {
                self.GoDict.Add(id, GoFound);
                self.GroupInfoDict.Add(id, info);

                switch (info.behType)
                {//初始化
                    case LightBehaviourType.Laser:
                        var childs = GoFound.GetComponentsInChildren<Transform>();
                        List<GameObject> lasers = new List<GameObject>();
                        foreach (var child in childs)
                        {
                            if (child.name == "Laser")
                            {
                                lasers.Add(child.gameObject);
                            }
                        }

                        if (lasers.Count > 0) info.handler.AddRange(lasers);
                        Log.Info($"{lasers.Count} GOs added for group {id}");
                        break;
                    case LightBehaviourType.SpotStop:
                        var childs2 = GoFound.GetComponentsInChildren<Transform>();
                        List<GameObject> volumes = new List<GameObject>();
                        foreach (var child in childs2)
                        {
                            if (child.name == "volume")
                            {
                                volumes.Add(child.gameObject);
                            }
                        }

                        if (volumes.Count > 0) info.handler.AddRange(volumes);
                        Log.Warning($"{volumes.Count} GOs added for group {id}");
                        break;
                    case LightBehaviourType.Strob:
                        var childs3 = GoFound.GetComponentsInChildren<Transform>();
                        foreach (var child in childs3)
                        {
                            if (child.name == "Spotik") info.handler.Add(child.gameObject);
                        }
                        break;
                    case LightBehaviourType.Cookie:
                        info.handler.Add(GoFound);

                        break;
                    default:
                        throw new NotImplementedException($"{info.behType} not implemented");
                        
                }

                self.OnOff(id, info.isOn);
                return GoFound;
            }

            return null;
        }

        public static void OnOff(this LightComponent self, int id, bool isOn)
        {
            var infoRes = self.GroupInfoDict.TryGetValue(id, out var info);
            if (!infoRes)
            {
                Log.Error($"light group {id} does not exist");
                return;
            }

            GameObject go = null;
            switch (info.behType)
            {
                case LightBehaviourType.Laser:
                    var goRes = self.GoDict.TryGetValue(id, out go);
                    if (goRes)
                    {
                        foreach (var gameObject in info.handler)
                        {
                            MeshRenderer meshRenderer= gameObject.GetComponent<MeshRenderer>();
                            if(meshRenderer) meshRenderer.enabled = isOn;
                        }
                    }
                    
                    break;
                case LightBehaviourType.SpotStop:
                    var goRes2 = self.GoDict.TryGetValue(id, out go);
                    if (goRes2)
                    {
                        foreach (var gameObject in info.handler)
                        {
                            MeshRenderer meshRenderer= gameObject.GetComponent<MeshRenderer>();
                            if(meshRenderer) meshRenderer.enabled = isOn;
                        }
                    }
                    break;
                case LightBehaviourType.Strob:
                    var goRes3 = self.GoDict.TryGetValue(id, out go);
                    if (goRes3)
                    {
                        foreach (var gameObject in info.handler)
                        {
                            gameObject.SetActive(isOn);
                        }
                    }
                    break;
                case LightBehaviourType.Cookie:
                    var resGo=self.GoDict.TryGetValue(id, out go);
                    if (resGo)
                    {
                        go.SetActive(isOn);
                        self.GroupInfoDict.TryGetValue(id, out var Info);
                        Info.isOn = isOn;
                        // Log.Info($"Setting lightgroup {id} on");
                    }
                    else
                    {
                        Log.Error($"Group {id} Light go does not exist!");
                    }
                    break;
                default:
                    throw new NotImplementedException($"{info.behType}not implemented");
            }
        }
        // public static void On(this LightComponent self,int id)
        // {
        //     var resGo=self.GoDict.TryGetValue(id, out GameObject go);
        //     if (resGo)
        //     {
        //         go.SetActive(true);
        //         self.GroupInfoDict.TryGetValue(id, out var Info);
        //         Info.isOn = true;
        //         // Log.Info($"Setting lightgroup {id} on");
        //     }
        //     else
        //     {
        //         Log.Error($"Group {id} Light go does not exist!");
        //     }
        //
        // }
        //
        // public static void Off(this LightComponent self,int id)
        // {
        //     var resGo=self.GoDict.TryGetValue(id, out GameObject go);
        //     if (resGo)
        //     {
        //         go.SetActive(false);
        //         self.GroupInfoDict.TryGetValue(id, out var Info);
        //         Info.isOn = false;
        //         // Log.Info($"Setting lightgroup {id} off");
        //     }
        //     else
        //     {
        //         Log.Error($"Group {id} Light go does not exist!");
        //     }
        //
        // }

        public static void StopMoving(this LightComponent self)
        {
            Log.Error("stop moving not implemented");
        }
        
    }
}