using System.IO;
using UnityEditor;
using UnityEngine;

public static class BuildWorld
{
    public const string output = "WorldOutput";

    [MenuItem("Tools/Build/Build world for Windows")]
    public static void WindowsBuild()
    {
        BuildForPlatform(output, BuildTarget.StandaloneWindows64, "windows");
        Debug.Log("Done (Windows).");
    }

    [MenuItem("Tools/Build/Build world for Linux")]
    public static void LinuxBuild()
    {
        BuildForPlatform(output, BuildTarget.StandaloneLinux64, "linux");
        Debug.Log("Done (Linux).");
    }

    [MenuItem("Tools/Build/Build world for MacOS")]
    public static void MacBuild()
    {
        BuildForPlatform(output, BuildTarget.StandaloneOSX, "macos");
        Debug.Log("Done (MacOS).");
    }

    [MenuItem("Tools/Build/Build world for all")]
    public static void AllBuild()
    {
        BuildForPlatform(output, BuildTarget.StandaloneWindows64, "windows");
        BuildForPlatform(output, BuildTarget.StandaloneLinux64, "linux");
        BuildForPlatform(output, BuildTarget.StandaloneOSX, "macos");
        Debug.Log("Done (All).");
    }

    private static void BuildForPlatform(string rootPath, BuildTarget target, string folderName)
    {
        string outputPath = Path.Combine(rootPath, folderName);

        if (!Directory.Exists(outputPath)) Directory.CreateDirectory(outputPath);
        BuildPipeline.BuildAssetBundles(outputPath, BuildAssetBundleOptions.None, target);

        Debug.Log($"Built AssetBundles for {target} -> {outputPath}");
    }
}