using HarmonyLib;

namespace SolastaLevel20.Patches
{
    class HeroDefinitionsPatcher
    {
        [HarmonyPatch(typeof(HeroDefinitions), "MaxHeroExperience")]
        internal static class HeroDefinitions_MaxHeroExperience_Patch
        {
            static bool Prefix(ref int __result)
            {
                __result = RuleDefinitions.ExperienceThresholds[Main.MOD_MAX_LEVEL - 1] - 1;
                return false;
            }
        }
    }
}