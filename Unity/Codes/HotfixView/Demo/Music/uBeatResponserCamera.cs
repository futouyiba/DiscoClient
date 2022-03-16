using DG.Tweening;
using ET.Demo.Sounds;
using UnityEngine;

namespace ET.Demo.Music
{

    
    public class uBeatResponsorCamera : MonoBehaviour
    {
    
        [SerializeField]
        private Camera _controlCamera;

        /// <summary>
        /// fov addition added to initfov
        /// </summary>
        [SerializeField]
        private float beatFocalChange=.5f;

        private float initFocalLength;
    
    
        // Start is called before the first frame update
        void Start()
        {
            SoundHelper.USoundMgr.AddBeatDlg(this.BeatPerform);
            this.initFocalLength = this._controlCamera.focalLength;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Init(Camera camera, float focalChange)
        {
            this._controlCamera = camera;
            this.beatFocalChange = focalChange;
        }

        private void BeatPerform()
        {
            DOTween.Kill(this);
            this._controlCamera.focalLength = this.initFocalLength;
            DOTween.To(() => this._controlCamera.focalLength, x => this._controlCamera.focalLength = x, this.beatFocalChange+this.initFocalLength, .12f);
        }
    }
}