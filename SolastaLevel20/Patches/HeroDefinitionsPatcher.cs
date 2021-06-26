using HarmonyLib;

namespace SolastaLevel20.Patches
{
    class HeroDefinitionsPatcher
    {
        [HarmonyPatch(typeof(HeroDefinitions), "MaxHeroExperience")]
        internal static class HeroDefinitions_MaxHeroExperience_Patch
        {
            internal static bool Prefix(ref int __result)
            {
                __result = 1000000;
                return false;
            }
        }
    }
}