using System;
using System.Collections.Generic;
using DG.Tweening;
using ET.Demo.Sounds;
using UnityEngine;
using ET.Demo.Music;
using ET.Music;

namespace ET.Demo.Sounds
{
    public static class SoundHelper
    {
        // private static uSoundMgr _uSoundMgr = null;xs
        // public static uSoundMgr USoundMgr
        // {
        //     get
        //     {
        //         if (_uSoundMgr != null)
        //         {
        //             return _uSoundMgr;
        //         }
        //         GameObject soundsGO = GameObject.Find("Sounds");
        //         _uSoundMgr = soundsGO.GetComponent<uSoundMgr>();
        //         if (!_uSoundMgr)
        //         {
        //             _uSoundMgr=soundsGO.AddComponent<uSoundMgr>();
        //         }
        //         return _uSoundMgr;
        //     }
        //
        // }

        // public static AudioSource musicSource
        // {
        //     get
        //     {
        //         return USoundMgr.gameObject.GetComponentInChildren<AudioSource>();
        //     }
        // }
        //
        private static string[] songNames = new string[5] {"PartyTrain_RedFoo","LoveStoryRemix","KrDisco","DJ_Gomi_Friday_Night_Fever","DJ_Alex_Ch_Disco" };
        /// <summary>
        /// 从ab包把歌曲都load进来
        /// 0317改到Helper中做，哪个MusicComponent想要就传给它们
        /// todo:异步做,LoadAssetByPath这个事是不是比较慢的事？也许可以加cache？
        /// </summary>
        public static IEnumerable<AudioClip> LoadSongsFromAB()
        {
            List<AudioClip> result = new List<AudioClip>();
            try
            {
                var bundleGameObject = AddressableComponent.Instance.LoadAssetByPath<GameObject>("MusicList.unity3d");
                for (int i = 0; i < songNames.Length; i++)
                {
                    result.Add(bundleGameObject.Get<AudioClip>(songNames[i]));
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return null;
            }

            return result;
        }

        
        
        /// <summary>
        /// 给unity中的物件挂上Monobehaviours
        /// 基本上是与节奏有关的东西
        /// 这个函数是为了联系热更层与Unity的第一种方法写的
        /// 这种方法在热更层保存了脚本，然后在创建GO时挂上它们然后初始化
        /// </summary>
        public static int AttachAllUnityComponents(MusicComponent musicComp)
        {
            int result = 0;
            //Speakers
            GameObject[] speakers = GameObject.FindGameObjectsWithTag("Speaker");
            var attachedSpeakerComps=AttachUnityComponent<uBeatResponserScale>(speakers);
            foreach (var attachedSpeakerComp in attachedSpeakerComps)
            {
                musicComp.AddBeatDlg(attachedSpeakerComp.Beat);
                
            }
            result += speakers.Length - 1;
            //Cameras
            UnityEngine.Camera[] cameras = UnityEngine.Camera.allCameras;
            List<GameObject> cameraGOs = new List<GameObject>();
            foreach (UnityEngine.Camera camera in cameras)
            {
                cameraGOs.Add(camera.gameObject);
                result++;
            }
            //初始化一下
            List<uBeatResponsorCamera> cameraBeaters = new List<uBeatResponsorCamera>();
            cameraBeaters = AttachUnityComponent<uBeatResponsorCamera>(cameraGOs) as List<uBeatResponsorCamera>;
            for (int i = 0; i < cameras.Length; i++)
            {//todo:read from config
                cameraBeaters[i].Init(cameras[i], .5f);
                musicComp.AddBeatDlg(cameraBeaters[i].BeatPerform);
                // musicComp.AddBeatScaleObj();
            }

            return result;
        }

        /// <summary>
        /// 给场景里的speaker类东西随低频波动的类
        /// </summary>
        /// <param name="gameObjects"></param>
        public static IEnumerable<T> AttachUnityComponent<T>(IEnumerable<GameObject> gameObjects) where T:UnityEngine.Component
        {
            List<T> attached=new List<T>();
            foreach (GameObject gameObject in gameObjects)
            {

                var addcomponent = gameObject.AddComponent<T>();

                attached.Add(addcomponent);
            }
            return attached;
        }

        /// <summary>
        /// 为某个GO添加一个Beat动画
        /// 这个函数是为了热更层与unity连接的第二种方法（把需要beatScale的物体存下来然后在需要beat的时候统一设置）写的
        /// 
        /// </summary>
        /// <param name="obj_To_Scale">变化的Gameobject</param>
        /// <param name="punchScale">原大小的百分比</param>
        /// <param name="duration">持续时间</param>
        public static void BeatScale(GameObject obj_To_Scale,float punchScale,float duration)
        {
            Transform transform1;
            (transform1 = obj_To_Scale.transform).DORewind();
            DOTween.Kill(transform1);
            obj_To_Scale.transform.DOPunchScale(Vector3.one * punchScale,duration);
        }
        

    }
}