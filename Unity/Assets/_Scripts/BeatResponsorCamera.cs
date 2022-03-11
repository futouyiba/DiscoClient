using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro.EditorUtilities;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class BeatResponsorCamera : MonoBehaviour
{
    
    [SerializeField]
    private Camera _controlCamera;

    /// <summary>
    /// fov addition added to initfov
    /// </summary>
    [SerializeField]
    private float beatFov;

    private float initFov;
    
    
    // Start is called before the first frame update
    void Start()
    {
        SoundMgr.instance.AddBeatDlg(this.BeatPerform);
        this.initFov = this._controlCamera.focalLength;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BeatPerform()
    {
        DOTween.Kill(this);
        this._controlCamera.focalLength = this.initFov;
        DOTween.To(() => this._controlCamera.focalLength, x => this._controlCamera.focalLength = x, this.beatFov+this.initFov, .12f);
    }
}
