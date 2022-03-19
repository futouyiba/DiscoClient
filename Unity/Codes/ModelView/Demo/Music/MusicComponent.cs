using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Music
{
    public class MusicComponent:Entity,IAwake
    {
        public bool SongsLoaded = false;
        public int currentSongIndex = 0;
        public AudioSource musicSource;
        public Action Dlg_Beat;
        public Dictionary<int, AudioClip> AudioClips = new Dictionary<int, AudioClip>();
        public GameObject MusicInst;


    }
}