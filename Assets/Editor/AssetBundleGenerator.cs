using System.IO;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class WorldBuilder
    {
        [MenuItem("World/Build")]
        static void Build()
        {
            BuildAssetBundles();
        }
    
        static void BuildAssetBundles()
        {
            string prefabsFolder = "Assets/World/Prefabs";
            string targetAssetBundleFolder = "Assets/AssetBundles";
            string[] prefabPaths = Directory.GetFiles(prefabsFolder, "*.prefab", SearchOption.AllDirectories);
        
            AssetBundleBuild[] buildMap = new AssetBundleBuild[prefabPaths.Length];

            for(int i = 0; i < prefabPaths.Length; i++)
            {
                buildMap[i].assetNames = new []{ prefabPaths[i] };
                buildMap[i].assetBundleName = Path.GetFileNameWithoutExtension(prefabPaths[i]);
            }
        
            Debug.Log("Found " + prefabPaths.Length + " prefabs in the '" + prefabsFolder + "' folder.");
        
            if (!Directory.Exists(targetAssetBundleFolder)) Directory.CreateDirectory(targetAssetBundleFolder);
        
            BuildPipeline.BuildAssetBundles("Assets/AssetBundles", buildMap, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);

            Debug.Log("Asset bundle generation complete.");

            AssetDatabase.Refresh();
        }
    }
}
