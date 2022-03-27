using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;
public class CCD
{
    public static string cds_url = "https://assetstreaming-content.unity.cn/client_api/v1/buckets/f7899c89-be43-40ab-80a8-6bac03654550/release_by_badge/latest/entry_by_path/content";    
    private Action<float> progress;
    private Action complete;
    public void Init(Action<float> progress,Action complete)
    {
        this.progress = progress;
        this.complete = complete;
    }
    public IEnumerator UpdateBundles()
    {
        Debug.Log("UpdateBundles");        
        var initHandle = Addressables.InitializeAsync();
        yield return initHandle;
        var updateCataHandle = Addressables.UpdateCatalogs();
        yield return updateCataHandle;
        if (updateCataHandle.Result!=null && updateCataHandle.Result.Count > 0)
        {
            var sizeHandle = Addressables.GetDownloadSizeAsync(updateCataHandle.Result[0].Keys);
            yield return sizeHandle;
            var totalDownLoadSize = sizeHandle.Result;
            Debug.Log("totalDownLoadSize:" + totalDownLoadSize);
            if (totalDownLoadSize > 0)
            {
                var downHandle = Addressables.DownloadDependenciesAsync(updateCataHandle.Result[0].Keys, Addressables.MergeMode.Union, false);
                while (!downHandle.IsDone)
                {
                    var percent = downHandle.PercentComplete;
                    progress?.Invoke(percent);
                }
                Addressables.Release(downHandle);
            }
            Addressables.Release(sizeHandle);
        }
        Addressables.Release(updateCataHandle);
        complete?.Invoke();
    }
}
