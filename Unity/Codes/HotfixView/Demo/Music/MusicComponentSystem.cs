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

       
        
    }
}