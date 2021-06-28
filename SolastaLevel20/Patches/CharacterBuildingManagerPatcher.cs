using HarmonyLib;
using static SolastaLevel20.Models.MultiClass;

namespace SolastaLevel20.Patches
{
    class CharacterBuildingManagerPatcher
    {
        private static bool flip = false;

        [HarmonyPatch(typeof(CharacterBuildingManager), "GetLastAssignedClassAndLevel")]
        internal static class CharacterBuildingManager_GetLastAssignedClassAndLevel_Patch
        {
            internal static bool Prefix(CharacterBuildingManager __instance, out CharacterClassDefinition lastClassDefinition, out int level)
            {
                if (__instance.HeroCharacter.ClassesHistory.Count <= 0)
                {
                    lastClassDefinition = null;
                    level = 0;
                }
                else
                {
                    lastClassDefinition = __instance.HeroCharacter.ClassesHistory[__instance.HeroCharacter.ClassesHistory.Count - 1];
                    level = __instance.HeroCharacter.ClassesAndLevels[lastClassDefinition];
                    if (flip)
                    {
                        var heroName = __instance.HeroCharacter.Name + __instance.HeroCharacter.SurName;
                        lastClassDefinition = NextHeroClass[heroName];
                    }
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(CharacterStageLevelGainsPanel), "EnterStage")]
        internal static class CharacterStageLevelGainsPanel_EnterStage_Patch
        {
            internal static void Prefix()
            {
                flip = true;
            }
            internal static void Postfix()
            {
                flip = false;
            }
        }
    }
}