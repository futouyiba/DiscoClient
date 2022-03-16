using ET.Demo.Sounds;
using UnityEngine;

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
    }
}