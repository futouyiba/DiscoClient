using DG.Tweening;
using ET.Demo.Sounds;
using ET.Music;
using ET.Sounds;
using UnityEngine;

namespace ET.Demo.Music
{
    public class uBeatResponserScale:MonoBehaviour
    {
        public static float beatCooldown = .2f;
        public Sequence beatAnimSeq;

        private Vector3 initScale;

        private Vector3 punchScale;
        // Start is called before the first frame update
        void Start()
        {
            // var result = SoundHelper.USoundMgr.AddBeatDlg(this.Beat);
            var result = Game.Scene.CurrentScene().GetComponent<SoundComponent>().GetComponent<MusicComponent>().AddBeatDlg(this.Beat);
            if(!result) Debug.LogError("add delegate for "+this.transform.parent.name+" failed");
            this.initScale = this.transform.localScale;
            this.punchScale = this.initScale * 1.2f;
            // this.beatAnimSeq= DOTween.Sequence()
            // .Append(this.transform.DOScale(this.punchScale, beatCooldown * .45f))
            // .Append(this.transform.DOScale(this.initScale, beatCooldown * .45f));
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void Beat()
        {
            // Debug.Log(Time.time+" beated");

            // this.beatAnimSeq.Play();

            Transform transform1;
            (transform1 = this.transform).DORewind();
            DOTween.Kill(transform1);
            this.transform.DOPunchScale(Vector3.one * .2f,beatCooldown*.9f);

        }

    }
}