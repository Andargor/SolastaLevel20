//using HarmonyLib;

//namespace SolastaLevel20.Patches
//{
//    class GuiCharacterPatcher
//    {
//        [HarmonyPatch(typeof(GuiCharacter), "SetupTooltip")]
//        internal static class GuiCharacter_SetupTooltip_Patch
//        {
//            internal static bool Prefix(GuiCharacter __instance, ITooltip tooltip, RulesetCharacterHero ___rulesetCharacterHero, RulesetCharacterHero.Snapshot ___snapshot)
//            {
//                if (___rulesetCharacterHero != null || ___snapshot != null)
//                    tooltip.Content = "ZAPP!!!" + __instance.FullName + " - " + __instance.LevelAndClassAndSubclass;
//                else
//                    tooltip.Content = "ZAPP!!!" + __instance.FullName;
//                return false;
//            }
//        }
//    }
//}