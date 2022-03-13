using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

namespace ET
{
    [ObjectSystem]
    public class AddressableComponentAwakeSystem : AwakeSystem<AddressableComponent>
    {
        public override void Awake(AddressableComponent self)
        {
            self.Awake();
        }
    }

    public class AddressableComponent : Entity, IAwake
    {
        public static AddressableComponent Instance { get; set; }

        /// <summary>
        /// Addressable����Ƿ��Ѿ���ʼ��
        /// </summary>
        private static bool initialize = false;

        public void Awake()
        {
            if (Instance != null)
            {
                Log.Error("�����ظ����Addressable�������");
            }
            else
            {
                Instance = this;
                Log.Info("���Addressable�������");
            }
        }

        /// <summary>
        /// Addressable�첽��ʼ��
        /// </summary>
        public ETTask AddressableInitializeAsync()
        {
            if (initialize)
            {
                Log.Error("Addressable�ظ���ʼ����");
                return null;
            }
            else
            {
                Log.Info("Addressable��ʼ��ʼ��");
                ETTask tcs = ETTask.Create();
                AsyncOperationHandle initializeHandle = Addressables.InitializeAsync();
                initializeHandle.Completed += (handle) =>
                {
                    Log.Info("Addressable��ʼ�����");
                    initialize = true;
                    tcs.SetResult();
                };

                return tcs.GetAwaiter();
            }
        }

        /// <summary>
        /// ��ȡ��Ҫ���µ���Դ�Ĵ�С(ͨ����ǩDefAssets��ȡ��������Ҫ���µ���Դ��Ҫ����DefAssets��ǩ)
        /// </summary>
        /// <returns>���ش�С����λByte���������0˵����Ҫ�и���</returns>
        public ETTask<long> AddressableGetDownloadSizeAsync()
        {
            if (initialize)
            {
                Log.Info("���ڼ���Ƿ��и�������");
                ETTask<long> tcs = ETTask<long>.Create();
                AsyncOperationHandle<long> downloadSizeHandle = Addressables.GetDownloadSizeAsync("DefAssets");
                downloadSizeHandle.Completed += (handle) =>
                {
                    tcs.SetResult(handle.Result);
                };
                return tcs.GetAwaiter();
            }
            else
            {
                Log.Error("Addressable��ȡ���ش�Сǰ�����ȳ�ʼ��");
                return null;
            }
        }

        /// <summary>
        /// ������Ҫ���µ���Դ(ͨ����ǩDefAssets���أ�������Ҫ���µ���Դ��Ҫ����DefAssets��ǩ)
        /// </summary>
        public async ETTask DownloadUpdateAssetsAsync()
        {
            if (initialize)
            {
                ETTask tcs = ETTask.Create();
                AsyncOperationHandle downloadHandle = Addressables.DownloadDependenciesAsync("DefAssets", true);

                long totalBytes = downloadHandle.GetDownloadStatus().TotalBytes;
                while (!downloadHandle.IsDone)
                {
                    DownloadStatus loadStatus = downloadHandle.GetDownloadStatus();
                    Log.Info("���ؽ��ȣ�" + (downloadHandle.PercentComplete * 100).ToString("0.00") + "%\t||\t���ش�С��" + (loadStatus.DownloadedBytes / 1024.0f).ToString("0.00") + "KB\t||\t�ܴ�С��" + (totalBytes / 1024.0f).ToString("0.00") + "KB");
                    await TimerComponent.Instance.WaitFrameAsync();
                }
                Log.Info("�������");
                tcs.SetResult();
            }
            else
            {
                Log.Error("��������ǰ�����ȳ�ʼ��");
            }
        }

        /// <summary>
        /// ͨ����Դ·��(AddressableName)ͬ������һ����Դ
        /// </summary>
        public T LoadAssetByPath<T>(string assetPath) where T : UnityEngine.Object
        {
            var op = Addressables.LoadAssetAsync<T>(assetPath);
            T asset = op.WaitForCompletion();
            return asset;
        }
        /// <summary>
        /// ͨ����Դ·��(AddressableName)�첽����һ����Դ
        /// </summary>
        public ETTask<T> LoadAssetByPathAsync<T>(string assetPath) where T : UnityEngine.Object
        {
            ETTask<T> tcs = ETTask<T>.Create(true);
            AsyncOperationHandle<T> assetHandle = Addressables.LoadAssetAsync<T>(assetPath);
            assetHandle.Completed += (handle) =>
            {
                tcs.SetResult(handle.Result);
                tcs = null;
            };
            return tcs.GetAwaiter();
        }

        /// <summary>
        /// ͨ����Դ·��(AddressableName)�첽����һ����Դ����Ҫж�������
        /// </summary>
        public ETTask<T> LoadAssetByPathAsync<T>(string assetPath, out AsyncOperationHandle<T> assetHandle) where T : UnityEngine.Object
        {
            ETTask<T> tcs = ETTask<T>.Create(true);
            assetHandle = Addressables.LoadAssetAsync<T>(assetPath);
            assetHandle.Completed += (handle) =>
            {
                tcs.SetResult(handle.Result);
                tcs = null;
            };
            return tcs.GetAwaiter();
        }

        /// <summary>
        /// ͨ����Դ·��(AddressableName)�첽����һ����Դ����ʵ����
        /// </summary>
        public ETTask<GameObject> LoadGameObjectAndInstantiateByPath(string assetPath, Transform parent = null, bool instantiateInWorldSpace = false, bool trackHandle = true)
        {
            ETTask<GameObject> tcs = ETTask<GameObject>.Create(true);
            AsyncOperationHandle<GameObject> assetHandle = Addressables.InstantiateAsync(assetPath, parent, instantiateInWorldSpace, trackHandle);
            assetHandle.Completed += (handle) =>
            {
                tcs.SetResult(handle.Result);
                tcs = null;
            };
            return tcs.GetAwaiter();
        }

        /// <summary>
        /// ͨ����Դ·��(AddressableName)�첽����һ����Դ����ʵ��������Ҫж�������
        /// </summary>
        public ETTask<GameObject> LoadGameObjectAndInstantiateByPath(string assetPath, out AsyncOperationHandle<GameObject> assetHandle, Transform parent = null, bool instantiateInWorldSpace = false, bool trackHandle = true)
        {
            ETTask<GameObject> tcs = ETTask<GameObject>.Create(true);
            assetHandle = Addressables.InstantiateAsync(assetPath, parent, instantiateInWorldSpace, trackHandle);
            assetHandle.Completed += (handle) =>
            {
                tcs.SetResult(handle.Result);
                tcs = null;
            };
            return tcs.GetAwaiter();
        }

        /// <summary>
        /// ͨ����Դ·��(AddressableName)�첽����һ����Դ����ʵ����
        /// </summary>
        public ETTask<GameObject> LoadGameObjectAndInstantiateByPath(string assetPath, Vector3 position, Quaternion rotation, Transform parent = null, bool trackHandle = true)
        {
            ETTask<GameObject> tcs = ETTask<GameObject>.Create(true);
            AsyncOperationHandle<GameObject> assetHandle = Addressables.InstantiateAsync(assetPath, position, rotation, parent, trackHandle);
            assetHandle.Completed += (handle) =>
            {
                tcs.SetResult(handle.Result);
                tcs = null;
            };
            return tcs.GetAwaiter();
        }

        /// <summary>
        /// ͨ����Դ·��(AddressableName)�첽����һ����Դ����ʵ��������Ҫж�������
        /// </summary>
        public ETTask<GameObject> LoadGameObjectAndInstantiateByPath(string assetPath, out AsyncOperationHandle<GameObject> assetHandle, Vector3 position, Quaternion rotation, Transform parent = null, bool trackHandle = true)
        {
            ETTask<GameObject> tcs = ETTask<GameObject>.Create(true);
            assetHandle = Addressables.InstantiateAsync(assetPath, position, rotation, parent, trackHandle);
            assetHandle.Completed += (handle) =>
            {
                tcs.SetResult(handle.Result);
                tcs = null;
            };
            return tcs.GetAwaiter();
        }

        /// <summary>
        /// ͨ��һ��Label�첽���ض����Դ
        /// </summary>
        /// <param name="label">��Ҫ���ص������Label</param>
        /// <param name="callBack">ÿ�������һ��ִ�лص�</param>
        /// <returns>���ط���Label������������Դ</returns>
        public ETTask<List<T>> LoadAssetsByLabelAsync<T>(string label, Action<T> callBack) where T : UnityEngine.Object
        {
            ETTask<List<T>> tcs = ETTask<List<T>>.Create(true);
            AsyncOperationHandle<IList<T>> assetHandle = Addressables.LoadAssetsAsync<T>(label, callBack);

            assetHandle.Completed += (handle) =>
            {
                tcs.SetResult(handle.Result.ToList<T>());
                tcs = null;
            };
            return tcs.GetAwaiter();
        }

        /// <summary>
        /// ͨ��һ��Label�첽���ض����Դ
        /// </summary>
        /// <param name="label">��Ҫ���ص������Label</param>
        /// <param name="callBack">ÿ�������һ��ִ�лص�</param>
        /// <returns>���ط���Label������������Դ</returns>
        public ETTask<List<T>> LoadAssetsByLabelAsync<T>(string label, out AsyncOperationHandle<IList<T>> assetHandle, Action<T> callBack) where T : UnityEngine.Object
        {
            ETTask<List<T>> tcs = ETTask<List<T>>.Create(true);
            assetHandle = Addressables.LoadAssetsAsync<T>(label, callBack);
            assetHandle.Completed += (handle) =>
            {
                tcs.SetResult(handle.Result.ToList<T>());
                tcs = null;
            };
            return tcs.GetAwaiter();
        }

        /// <summary>
        /// ͨ�����Label�첽���ض����Դ
        /// </summary>
        /// <param name="labels">��Ҫ���ص����������Label</param>
        /// <param name="callBack">ÿ�������һ��ִ�лص�</param>
        /// <param name="mergeMode">Label�ϲ�ģʽ</param>
        /// <returns>���ط���Label������������Դ</returns>
        public ETTask<List<T>> LoadAssetsByLabelAsync<T>(List<string> labels, Action<T> callBack, Addressables.MergeMode mergeMode = Addressables.MergeMode.None) where T : UnityEngine.Object
        {
            ETTask<List<T>> tcs = ETTask<List<T>>.Create(true);
            AsyncOperationHandle<IList<T>> assetHandle = Addressables.LoadAssetsAsync<T>(labels, callBack, mergeMode);
            assetHandle.Completed += (handle) =>
            {
                tcs.SetResult(handle.Result.ToList<T>());
                tcs = null;
            };
            return tcs.GetAwaiter();
        }

        /// <summary>
        /// ͨ�����Label�첽���ض����Դ����Ҫж�������
        /// </summary>
        /// <param name="labels">��Ҫ���ص����������Label</param>
        /// <param name="callBack">ÿ�������һ��ִ�лص�</param>
        /// <param name="mergeMode">Label�ϲ�ģʽ</param>
        /// <returns>���ط���Label������������Դ</returns>
        public ETTask<List<T>> LoadAssetsByLabelAsync<T>(List<string> labels, out AsyncOperationHandle<IList<T>> assetHandle, Action<T> callBack, Addressables.MergeMode mergeMode = Addressables.MergeMode.None) where T : UnityEngine.Object
        {
            ETTask<List<T>> tcs = ETTask<List<T>>.Create(true);
            assetHandle = Addressables.LoadAssetsAsync<T>(labels, callBack, mergeMode);
            assetHandle.Completed += (handle) =>
            {
                tcs.SetResult(handle.Result.ToList<T>());
                tcs = null;
            };
            return tcs.GetAwaiter();
        }

        /// <summary>
        /// ͨ������·��(AddressableName)�첽���س���
        /// </summary>
        /// /// <param name="scenePath">������Դ��·��(AddressableName)</param>
        /// <param name="sceneInstanceHandle">�������صľ����ж�ص�ʱ����</param>
        /// <param name="activateOnLoad">���غ��Ƿ����̼��������SceneManager.SetActiveScene()������������Ӱ��������Դ�첽������ɺ�Ļص�</param>
        /// <returns>����SceneInstance���ݣ�����ͨ�����ֱ�ӻ�ȡ��</returns>
        public ETTask<SceneInstance> LoadSceneByPathAsync(string scenePath, out AsyncOperationHandle<SceneInstance> sceneInstanceHandle, UnityEngine.SceneManagement.LoadSceneMode loadMode = UnityEngine.SceneManagement.LoadSceneMode.Single, bool activateOnLoad = true, int priority = 100)
        {
            ETTask<SceneInstance> tcs = ETTask<SceneInstance>.Create();
            sceneInstanceHandle = Addressables.LoadSceneAsync(scenePath, loadMode, activateOnLoad, priority);
            sceneInstanceHandle.Completed += (handle) =>
            {
                SceneInstance sceneInstance = handle.Result;
                tcs.SetResult(sceneInstance);
            };
            return tcs.GetAwaiter();
        }

        /// <summary>
        /// ������صĳ���
        /// </summary>
        public ETTask ActivateLoadScene(SceneInstance sceneInstance)
        {
            ETTask tcs = ETTask.Create();
            AsyncOperation asyncOperation = sceneInstance.ActivateAsync();
            asyncOperation.completed += (operation) =>
            {
                tcs.SetResult();
            };
            return tcs.GetAwaiter();
        }
        /// <summary>
        /// ͨ�����ж��Addressables��Դ
        /// </summary>
        public void UnLoadAsset(AsyncOperationHandle handle)
        {
            Addressables.Release(handle);
        }

        /// <summary>
        /// ͨ�����;��ж��Addressables��Դ
        /// </summary>
        public void UnLoadAsset<T>(AsyncOperationHandle<T> handle) where T : UnityEngine.Object
        {
            Addressables.Release<T>(handle);
        }

        /// <summary>
        /// ͨ�����ص���Դ������ж����Դ
        /// </summary>
        public void UnLoadAsset<T>(T assets) where T : UnityEngine.Object
        {
            Addressables.Release(assets);
        }

        /// <summary>
        /// ͨ�����ж��ʵ�������ض���һ��������Դ
        /// </summary>
        public void UnLoadInstanceAsset(AsyncOperationHandle handle)
        {
            Addressables.ReleaseInstance(handle);
        }

        /// <summary>
        /// ͨ�����ж��ʵ�������ض���һ��������Դ
        /// </summary>
        public void UnLoadInstanceAsset(AsyncOperationHandle<GameObject> handle)
        {
            Addressables.ReleaseInstance(handle);
        }

        /// <summary>
        /// ж��ʵ�������ض���һ��������Դ
        /// </summary>
        /// <param name="instanceObj">ʵ������Gameobject</param>
        public void UnLoadInstanceAsset(GameObject instanceObj)
        {
            Addressables.ReleaseInstance(instanceObj);
        }

        /// <summary>
        /// ͨ���������صľ���첽ж�س���
        /// </summary>
        public ETTask UnLoadSceneAsync(AsyncOperationHandle asyncOperationHandle)
        {
            ETTask tcs = ETTask.Create();
            Addressables.UnloadSceneAsync(asyncOperationHandle).Completed += (handle) =>
            {
                tcs.SetResult();
            };
            return tcs.GetAwaiter();
        }

        /// <summary>
        /// ͨ���������صľ�������첽ж�س���
        /// </summary>
        public ETTask UnLoadSceneAsync<T>(AsyncOperationHandle<T> asyncOperationHandle)
        {
            ETTask tcs = ETTask.Create();
            Addressables.UnloadSceneAsync(asyncOperationHandle).Completed += (handle) =>
            {
                tcs.SetResult();
            };
            return tcs.GetAwaiter();
        }

        /// <summary>
        /// ͨ������ʵ��������ж�س���
        /// </summary>
        public ETTask UnLoadSceneAsync(SceneInstance sceneInstance)
        {
            ETTask tcs = ETTask.Create();
            Addressables.UnloadSceneAsync(sceneInstance).Completed += (handle) =>
            {
                tcs.SetResult();
            };
            return tcs.GetAwaiter();
        }
    }
}

