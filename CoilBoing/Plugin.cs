using System.IO;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace CoilBoing;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    private static AudioClip[] _boingSound;
    
    private void Awake()
    {
        string dir = Directory.GetParent(Info.Location)!.FullName;
        string bundlePath = Path.Combine(dir, "boing");
        var bundle = AssetBundle.LoadFromFile(bundlePath);
        foreach (var asset in bundle.LoadAllAssets())
        {
            Logger.LogInfo(asset.GetType() + " " + asset.name);
        }
        _boingSound = bundle.LoadAssetWithSubAssets<AudioClip>("boing");
        Logger.LogInfo("Loaded sound " + _boingSound + " " + _boingSound.Length);
        Harmony.CreateAndPatchAll(typeof(Patches));
        Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
    }
    
    private class Patches
    {
        [HarmonyPatch(typeof(EnemyAI), nameof(EnemyAI.Start))]
        [HarmonyPostfix]
        private static void ChangeSproingSound(EnemyAI __instance)
        {
            if (__instance is SpringManAI sproing)
            {
                sproing.springNoises = _boingSound;
            }
        }
    }
}
