using LogicAPI.Client;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace FoxFireFive.CustomWorlds.Client
{
    public class CustomWorldLoader : ClientMod
    {
        private readonly List<AssetBundle> loaded = [];

        private void LoadAllBundles(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Debug.LogError($"worlds folder not found: {folderPath}");
                return;
            }

            foreach (var file in Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories))
            {
                if (file.EndsWith(".manifest"))
                    continue;

                var bundle = AssetBundle.LoadFromFile(file);

                if (bundle == null)
                {
                    Debug.LogWarning($"Failed to load AssetBundle: {file}");
                    continue;
                }

                loaded.Add(bundle);

                Debug.Log($"Loaded bundle: {Path.GetFileName(file)}");
            }
        }

        protected override void Initialize()
        {
            string assetsPath = Path.Combine(Files.Path, "worlds");
            LoadAllBundles(assetsPath);
        }
    }
}