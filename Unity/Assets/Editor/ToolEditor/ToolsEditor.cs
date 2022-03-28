using System.IO;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace ET
{
    public static class ToolsEditor
    {
        [MenuItem("Tools/ExcelExporter")]
        public static async void ExcelExporter()
        {
#if UNITY_EDITOR_OSX
            const string tools = "./Tools";
#else
            const string tools = ".\\Tools.exe";
#endif
            await Task.Run(() => ShellHelper.Run($"{tools} --AppType=ExcelExporter --Console=1", "../Bin/"));
            ConfigSetup();
            
        }

        // [MenuItem("Tools/ConfigSetup")]
        private static void ConfigSetup()
        {
            const string basepath = "Assets/Bundles/Config";
            string prefabPath = Path.Combine(basepath, "config.prefab");
            var prefabFile = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            var byteFiles = Directory.GetFiles(basepath, "*.bytes");
            var refCollector = prefabFile.GetComponent<ReferenceCollector>();
            
            refCollector.Clear();
            foreach (var byteFile in byteFiles)
            {
                string key = Path.GetFileNameWithoutExtension(byteFile);
                var file = AssetDatabase.LoadAssetAtPath<Object>(byteFile);
                refCollector.Add(key, file);
            }
            // var res = AssetDatabase.LoadAllAssetsAtPath(prefabPath);
            Debug.Log($"{refCollector.data.Count} assets added");
            // AssetDatabase.LoadAssetAtPath(path)
        }
        
        [MenuItem("Tools/Proto2CS")]
        public static void Proto2CS()
        {
#if UNITY_EDITOR_OSX
            const string tools = "./Tools";
#else
            const string tools = ".\\Tools.exe";
#endif
            ShellHelper.Run($"{tools} --AppType=Proto2CS --Console=1", "../Bin/");
        }
    }
}