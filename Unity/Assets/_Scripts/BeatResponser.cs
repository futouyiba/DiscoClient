using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BeatResponser : MonoBehaviour
{
    
    public static float beatCooldown = .2f;
    public Sequence beatAnimSeq;

    private Vector3 initScale;

    private Vector3 punchScale;
    // Start is called before the first frame update
    void Start()
    {
        var result = SoundMgr.instance.AddBeatDlg(this.Beat);
        
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
        
        this.transform.DORewind();
        DOTween.Kill(this.transform);
        this.transform.DOPunchScale(Vector3.one * .2f,beatCooldown*.9f);

    }
    
}
