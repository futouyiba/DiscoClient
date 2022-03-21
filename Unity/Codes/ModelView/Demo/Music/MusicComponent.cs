using System;
using System.Collections.Generic;
using UnityEngine;

namespace ET.Music
{
    public class MusicComponent:Entity,IAwake,IUpdate
    {
        public bool SongsLoaded = false;
        public int currentSongIndex = 0;
        public AudioSource musicSource;
        public Action Dlg_Beat;
        public Func<GameObject, float, float> Dlg_BeatFunc;
        public Dictionary<int, AudioClip> AudioClips = new Dictionary<int, AudioClip>();
        public GameObject MusicInst;
        
        public float[] spectrumData = new float[1024];
        public Vector2Int SpectRange = new Vector2Int(0, 255);
        public float tensityMultiply=100f;
        public float beatThreshold=.11f;
        public List<GameObject> BeatScaleObjs= new List<GameObject>();



    }
}