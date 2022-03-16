using System.Collections.Generic;
using UnityEngine;

namespace ET.Music
{
    public class MusicComponent:Entity
    {
        public bool SongsLoaded = false;
        public int currentSongIndex = 0;
        public Dictionary<int, AudioClip> AudioClips = new Dictionary<int, AudioClip>();

        

    }
}