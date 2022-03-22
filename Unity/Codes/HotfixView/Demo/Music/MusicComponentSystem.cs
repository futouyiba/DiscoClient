using System;
using System.Collections.Generic;
using System.Linq;
using ET.Demo.Sounds;
using ET.Music;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Demo.Music
{
    [ObjectSystem]
    public class MusicComponentAwakeSystem: AwakeSystem<MusicComponent>
    {
        public override void Awake(MusicComponent self)
        {
            try
            {
                MusicConfigCategory musicConfigCategory = MusicConfigCategory.Instance;
                var configGot = musicConfigCategory.Get(1);
                // Log.Warning($"spect range= {configGot.SpectRangeMin},{configGot.SpectRangeMax};");
                //初始化一下自己
                int finalSampleSize = (int)Math.Pow(2 , configGot.SampleSize);
                if (self.spectrumData.Length != finalSampleSize)
                {
                    self.spectrumData = new float[finalSampleSize];
                }

                self.SpectRange.x = configGot.SpectRangeMin;
                self.SpectRange.y = configGot.SpectRangeMax;
                self.tensityMultiply = (float) configGot.tensityMultiply;
                self.beatThreshold = (float) configGot.beatThreshold;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }


        }
    }

    [ObjectSystem]
    public class MusicComponentUpdateSystem: UpdateSystem<MusicComponent>
    {
        public override void Update(MusicComponent self)
        { 
            //获取频谱
            //现在只听通道0，todo：立体声多通道平均音量好一点？
            AudioListener.GetSpectrumData(self.spectrumData, 0, FFTWindow.BlackmanHarris);
            float tensity = 0f;
            // Vector2Int sampleRange = new Vector2Int(0, 255);
            for (int i=self.SpectRange.x; i <= self.SpectRange.y; i++)
            {
                tensity += self.spectrumData[i];
            }

            tensity /= (float)(self.SpectRange.y - self.SpectRange.x + 1);
        
            // if (tensity >= this.tenseMax)
            // {
            //     this.tenseMax = tensity;
            // }
            // Debug.Log("tensitymax="+this.tenseMax);
        
            //有一些magic numbers
            if (tensity * self.tensityMultiply >= self.beatThreshold)
            {//found beat
                self.Dlg_Beat?.Invoke();
                
                // foreach (var beatObj in self.BeatScaleObjs)
                // {
                //     SoundHelper.BeatScale(beatObj, .2f, .2f);
                // }
            }

        }
    }
    
    public static class MusicComponentSystem
    {

        public static GameObject CreateGO(this MusicComponent self)
        {
            //create game objects
            GameObject musicPrefab = null;
            try
            {
                var bundleGameObject = AddressableComponent.Instance.LoadAssetByPath<GameObject>("SoundsCollector.unity3d");
                musicPrefab = bundleGameObject.Get<GameObject>("MusicPrefab");

            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            if (!musicPrefab)
            {
                Debug.LogError("create music prefab failed");
                return null;
            }

            var musicGO = UnityEngine.Object.Instantiate(musicPrefab);
            self.MusicInst = musicGO;
            self.musicSource = musicGO.GetComponent<AudioSource>();
            return musicGO;
        }

        public static bool AddBeatDlg(this MusicComponent self,Action func)
        {
            try
            {
                self.Dlg_Beat += func;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return false;
            }

            return true;
        }

        public static bool AddBeatDlg(this MusicComponent self, Func<GameObject, float, float> func)
        {
            try
            {
                self.Dlg_BeatFunc += func;
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return false;
            }

            return true;
        }

        /// <summary>
        /// 这个函数把需要做scale变化的GO存起来，以便之后加动画
        /// </summary>
        /// <param name="self"></param>
        /// <param name="obj"></param>
        public static void AddBeatScaleObj(this MusicComponent self, GameObject obj)
        {
            if (self.BeatScaleObjs.Contains(obj)) return;
            self.BeatScaleObjs.Add(obj);
        }
        
        public static void AddBeatScaleObj(this MusicComponent self, IEnumerable<GameObject> objs)
        {
            List<GameObject> addObjs = new List<GameObject>();
            foreach (var obj in objs)
            {
                if (self.BeatScaleObjs.Contains(obj))
                {
                    ET.Log.Warning($"Adding existing obj {obj.name}");
                    continue;
                }

                addObjs.Add(obj);
            }
            self.BeatScaleObjs.AddRange(addObjs);
        }
        
        public static bool LoadSongs(this MusicComponent self,IEnumerable<AudioClip> songs)
        {
            if (songs == null)
            {
                Debug.LogError("loading songs is null");
                return false;
            }
        
            int i = 0;
            foreach (var song in songs)
            {
                self.AudioClips.Add(i,song);
                i++;
            }

            self.SongsLoaded = true;
            return true;

        }

        public static void PlaySong(this MusicComponent self,int index)
        {
            if (!self.SongsLoaded)
            {
                var result = LoadSongs(self, SoundHelper.LoadSongsFromAB());
                if (!result) Debug.LogError("loadsongs failed");
            }
            var source=self.musicSource;
            source.clip = self.AudioClips[index];
            source.Play();
        }
        
        public static void PlaySong(this MusicComponent self,int index, float time)
        {
            if (!self.SongsLoaded)
            {
                var result = LoadSongs(self, SoundHelper.LoadSongsFromAB());
                if (!result) Debug.LogError("loadsongs failed");
            }
            var source=self.musicSource;
            source.clip = self.AudioClips[index];
            var length = source.clip.length;
            Log.Info($"Music playback time {time}, modulus {time % length}");
            PlayBackTime(self,time % length);
            source.Play();
        }
        
        public static void CutSong(this MusicComponent self, int newIndex)
        {
            var source=self.musicSource;
            source.Stop();
            source.clip = self.AudioClips[newIndex];
            source.Play();
            Log.Info($"music component cut song:{newIndex}");
        }

        public static void PlayBackTime(this MusicComponent self, float timeInSec)
        {
            self.musicSource.time = timeInSec;
        }

       
        
    }
}