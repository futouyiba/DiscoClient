using UnityEngine;

namespace ET.Sounds
{
    public class SoundComponent:Entity,IAwake
    {
        public AudioClip[] CachedAudioClips;
    }
}