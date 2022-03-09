using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class BeatResponser : MonoBehaviour
{
    
    public static float beatCooldown = .1f;

    private Vector3 initScale;

    private Vector3 punchScale;
    // Start is called before the first frame update
    void Start()
    {
        SoundMgr.instance.AddBeatDlg(this.Beat);
        this.initScale = this.transform.localScale;
        this.punchScale = this.initScale * 1.2f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Beat()
    {

        this.transform.DOScale(this.punchScale, beatCooldown * .45f).onComplete(DOTween.(this.punchScale, beatCooldown * .45f));
        
    }
    
}
