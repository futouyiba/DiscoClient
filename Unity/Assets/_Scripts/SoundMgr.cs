using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

// using NAudio；

//让其他组件容易的找到当前的audio source
//
public class SoundMgr : MonoBehaviour
{
    public static SoundMgr instance { get; private set; }

    [Header("Music")]
    [SerializeField]
    private AudioSource musicSource;

    [SerializeField]
    private List<AudioClip> musicList;

    [Header("Spectrum")]
    /// <summary>
    /// 1024 samples by def
    /// from x to y
    /// </summary>
    [SerializeField]
    private Vector2Int SpectRange;

    private float[] spectrumData;
    public static float tensityMultiply = 100f;

    [SerializeField]
    private float beatThreshold = .15f;

    // [SerializeField] private float delay = 0f;
    
    private float tenseMax;
    //存放beat表现的dlg定义
    public Action dlg_Beat;
    private float lastBeat;

   

    // public dlg_Beat Dlg_beat;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }

        else
        {
            instance = this;
            this.Init();
        }
    }

    private void Init()
    {
        spectrumData=new float[1024];
        this.tenseMax= 0f;
        // this.SpectRange = new Vector2Int(0, 255);
    }
    
    //从配置的列表中随机播放音乐
    public void PlayRandom()
    {
        if (this.musicList != null && this.musicList.Count > 0)
        {
            this.StopMusic();
            var chosenNum = Random.Range(0, this.musicList.Count);
            this.musicSource.clip = this.musicList[chosenNum];
            this.musicSource.Play();
        }
    }

    public void StopMusic()
    {
        if (this.musicSource.isPlaying)
        {
            this.musicSource.Stop();
        }
    }
    
    
    //从音频开搞还是配置？
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.X))
        {
            this.PlayRandom();
        }
    }


    
    void FixedUpdate()
    {
        //获取频谱
        //现在只听通道0，todo：立体声多通道平均音量好一点？
        AudioListener.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);
        float tensity = 0f;
        // Vector2Int sampleRange = new Vector2Int(0, 255);
        for (int i=this.SpectRange.x; i <= this.SpectRange.y; i++)
        {
            tensity += this.spectrumData[i];
        }

        tensity /= (float)(SpectRange.y - SpectRange.x + 1);
        
        // if (tensity >= this.tenseMax)
        // {
        //     this.tenseMax = tensity;
        // }
        // Debug.Log("tensitymax="+this.tenseMax);
        
        //有一些magic numbers
        if (tensity * tensityMultiply >= this.beatThreshold)
        {//found beat
            
            // Debug.Log(Time.time+" BeatFound"+" tensity="+tensity+", threshold="+this.beatThreshold);
            this.dlg_Beat.Invoke();
            this.lastBeat = Time.time;
        }
        
    }


    public bool AddBeatDlg(Action func)
    {
        try
        {
            this.dlg_Beat += func;
        }
        catch(Exception e)
        {
            Debug.LogError(e);
            return false;
        }
        return true;
    }
}

