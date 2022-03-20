using System;
using System.Collections.Generic;
using System.Linq;
using ET.Demo.Sounds;
using ET.Music;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Demo.Music
{
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
        
        public static void CutSong(this MusicComponent self, int newIndex)
        {
            var source=self.musicSource;
            source.Stop();
            source.clip = self.AudioClips[newIndex];
            source.Play();
        }

       
        
    }
}