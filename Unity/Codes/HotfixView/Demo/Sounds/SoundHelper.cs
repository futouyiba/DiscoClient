using System;
using System.Collections.Generic;
using ET.Demo.Sounds;
using UnityEngine;
using ET.Demo.Music;

namespace ET.Demo.Sounds
{
    public static class SoundHelper
    {
        private static uSoundMgr _uSoundMgr = null;
        public static uSoundMgr USoundMgr
        {
            get
            {
                if (_uSoundMgr != null)
                {
                    return _uSoundMgr;
                }
                GameObject soundsGO = GameObject.Find("Sounds");
                _uSoundMgr = soundsGO.GetComponent<uSoundMgr>();
                if (!_uSoundMgr)
                {
                    _uSoundMgr=soundsGO.AddComponent<uSoundMgr>();
                }
                return _uSoundMgr;
            }

        }

        public static AudioSource musicSource
        {
            get
            {
                return USoundMgr.gameObject.GetComponentInChildren<AudioSource>();
            }
        }
        
        private static string[] songNames = new string[5] {"PartyTrain_RedFoo","LoveStoryRemix","KrDisco","DJ_Gomi_Friday_Night_Fever","DJ_Gomi_Friday_Night_Fever" };
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
        /// </summary>
        public static void AttachAllUnityComponents()
        {
            //Speakers
            GameObject[] speakers = GameObject.FindGameObjectsWithTag("Speaker");
            AttachUnityComponent<uBeatResponserScale>(speakers);
            //Cameras
            Camera[] cameras = Camera.allCameras;
            List<GameObject> cameraGOs = new List<GameObject>();
            foreach (Camera camera in cameras)
            {
                cameraGOs.Add(camera.gameObject);
            }
            //初始化一下
            List<uBeatResponsorCamera> cameraBeaters = new List<uBeatResponsorCamera>();
            cameraBeaters = AttachUnityComponent<uBeatResponsorCamera>(cameraGOs) as List<uBeatResponsorCamera>;
            for (int i = 0; i < cameras.Length; i++)
            {//todo:read from config
                cameraBeaters[i].Init(cameras[i], .5f);
            }

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

    }
}