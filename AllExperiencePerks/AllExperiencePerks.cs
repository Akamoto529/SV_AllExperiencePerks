using BepInEx;
using HarmonyLib;

namespace all_experience_perks
{
	public class PluginInfo
	{
		public const string PLUGIN_GUID = "com.akamoto.all_experience_perks";
		public const string PLUGIN_NAME = "AllExperiencePerks";
		public const string PLUGIN_VERSION = "1.0.0";
	}

	[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
	[BepInProcess("Star Valor.exe")]
	public class Plugin : BaseUnityPlugin
	{
		private void Awake()
		{
			// Plugin startup logic
			Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
			Harmony.CreateAndPatchAll(typeof(Plugin));
		}

		[HarmonyPatch(typeof(CharacterScreen), "Open")]
		[HarmonyPostfix]
		public static void Open(int mode)
		{
			int[] perks = { 100, 101, 110, 120, 130, 140, 141, 142, 150, 151, 152, 160, 161, 180, 190, 191 };
            foreach (var perk in perks)
            {
				if (!PChar.HasPerk(perk))
				{
					PChar.AddPerk(perk);
				}
			}
		}
	}
}