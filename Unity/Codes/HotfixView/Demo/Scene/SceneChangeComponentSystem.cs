using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ET
{
    public class SceneChangeComponentUpdateSystem: UpdateSystem<SceneChangeComponent>
    {
        public override void Update(SceneChangeComponent self)
        {
            if (!self.loadMapOperation.isDone)
            {
                self.SetIntForTMP(self.Process());
                return;
            }

            if (self.tcs == null)
            {
                return;
            }
            
            ETTask tcs = self.tcs;
            self.tcs = null;
            tcs.SetResult();
        }


    }

    public class SceneChangeComponentAwakeSystem: AwakeSystem<SceneChangeComponent>
    {
        public override void Awake(SceneChangeComponent self)
        {
            // self.UpdateProcess();
            // Log.Warning("setting up updateprocess on awake");
        }
    }


    public class SceneChangeComponentDestroySystem: DestroySystem<SceneChangeComponent>
    {
        public override void Destroy(SceneChangeComponent self)
        {
            self.loadMapOperation = null;
            self.tcs = null;
        }
    }

    public static class SceneChangeComponentSystem
    {
        public static async ETTask ChangeSceneAsync(this SceneChangeComponent self, string sceneName)
        {
            self.tcs = ETTask.Create(true);
            // 加载map
            self.loadMapOperation = SceneManager.LoadSceneAsync(sceneName);
            //this.loadMapOperation.allowSceneActivation = false;
            await self.tcs;
        }
        
        public static int Process(this SceneChangeComponent self)
        {
            if (self.loadMapOperation == null)
            {
                return 0;
            }
            return (int)(self.loadMapOperation.progress * 100);
        }
        
        // public static async void UpdateProcess(this SceneChangeComponent self, int updateFreq = 300)
        // {
        //     do
        //     {   
        //         // Log.Error($"{TimeHelper.ClientNow()} updating process");
        //         self.Dlg_UpdateProcess?.Invoke(self.Process());
        //         await TimerComponent.Instance.WaitAsync(updateFreq);
        //     }
        //     while (!self.loadMapOperation.isDone);
        // }

        
        // public static void AddDlgProcessView(this SceneChangeComponent self, Action<int> func)
        // {
        //     if (func == null)
        //     {
        //         Log.Error($"func adding is null");
        //         return;
        //     }
        //     self.Dlg_UpdateProcess += func;
        // }
        

        // public static bool TryBindProcessView(this SceneChangeComponent self)
        // {
        //     self.AddDlgProcessView(SetIntForTMP);
        //     return true;
        // }
        
        public static void SetIntForTMP(this SceneChangeComponent self,int setNumber)
        {
            if (self.tmp == null)
            {
                var go = GameObject.FindGameObjectWithTag("SceneProcessView");
                if (go == null)
                {
                    // Log.Warning("SceneProcessView not found");
                    return;
                }
                self.tmp = go.GetComponent<TextMeshPro>();
                if (self.tmp == null)
                {
                    Log.Error($"get tmp comp failed");
                    return;
                }
            }
            

            // Log.Warning($"setting process to {setNumber} for tmp!");
            self.tmp.SetText(setNumber.ToString());
        }

        
    }
}