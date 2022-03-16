using System;
using System.Collections.Generic;
using System.Linq;
using ET.Demo.Sounds;
using ET.Music;
using UnityEngine;

namespace ET.Demo.Music
{
    public static class MusicComponentSystem
    {

        private static string[] songNames = new string[5] {"PartyTrain_RedFoo","LoveStoryRemix","KrDisco","DJ_Gomi_Friday_Night_Fever","DJ_Gomi_Friday_Night_Fever" };
        /// <summary>
        /// 从ab包把歌曲都load进来
        /// todo:异步做
        /// </summary>
        /// <param name="self"></param>
        public static bool LoadSongs(this MusicComponent self)
        {
            try
            {
                var bundleGameObject = AddressableComponent.Instance.LoadAssetByPath<GameObject>("MusicList.unity3d");
                for (int i = 0; i < songNames.Length; i++)
                {
                    self.AudioClips.Add(i, bundleGameObject.Get<AudioClip>(songNames[i]));
                }

                self.SongsLoaded = true;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return false;
            }

            return true;
        }

        public static void PlaySong(this MusicComponent self,int index)
        {
            if (!self.SongsLoaded)
            {
                self.LoadSongs();
            }
            var source=SoundHelper.musicSource;
            source.clip = self.AudioClips[index];
            source.Play();
        }
        
        public static void CutSong(this MusicComponent self, int newIndex)
        {
            var source=SoundHelper.musicSource;
            source.Stop();
            source.clip = self.AudioClips[newIndex];
            source.Play();
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