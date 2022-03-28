using System.Collections.Generic;
using UnityEngine;

namespace ET
{
    public class ConfigLoader: IConfigLoader
    {

        public void GetAllConfigBytes(Dictionary<string, byte[]> output)
        {
            var loaded = AddressableComponent.Instance.LoadAssetByPath<GameObject>("config.unity3d");
            var refCollector = loaded.GetComponent<ReferenceCollector>();
            foreach (var refItem in refCollector.data)
            {
                TextAsset v= refItem.gameObject as TextAsset;
                string k = refItem.key;
                output[k] = v.bytes;
            }

            // Dictionary<string, UnityEngine.Object> keys = ResourcesComponent.Instance.GetBundleAll("config.unity3d");

            // foreach (var kv in keys)
            // {
            //     TextAsset v = kv.Value as TextAsset;
            //     string key = kv.Key;
            //     output[key] = v.bytes;
            // }
        }

        public byte[] GetOneConfigBytes(string configName)
        {
            // TextAsset v = ResourcesComponent.Instance.GetAsset("config.unity3d", configName) as TextAsset;
            // return v.bytes;
            var loaded = AddressableComponent.Instance.LoadAssetByPath<GameObject>("config.unity3d");
            return loaded.Get<TextAsset>(configName).bytes;
        }
    }
}