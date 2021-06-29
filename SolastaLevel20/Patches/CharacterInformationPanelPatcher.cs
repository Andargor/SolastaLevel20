using HarmonyLib;
using System.Collections.Generic;
using System.Reflection.Emit;
using static SolastaLevel20.Models.ClassPicker;

namespace SolastaLevel20.Patches
{
    class CharacterInformationPanelPatcher
    {
        [HarmonyPatch(typeof(CharacterInformationPanel), "Bind")]
        internal static class CharacterInformationPanel_Bind_Patch
        {
            internal static void Postfix(CharacterInformationPanel __instance)
            {
                CollectHeroClasses(__instance.InspectedCharacter.RulesetCharacterHero);
            }
        }

        [HarmonyPatch(typeof(CharacterInformationPanel), "Refresh")]
        internal static class CharacterInformationPanel_EnumerateClassBadges_Patch
        {
            private static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var containsMethod = typeof(string).GetMethod("Contains");
                var getSearchTermMethod = typeof(SolastaLevel20.Models.ClassPicker).GetMethod("GetSelectedClassSearchTerm");
                var found = 0;

                foreach (var instruction in instructions)
                {
                    if (instruction.Calls(containsMethod))
                    {
                        found++;
                        if (found == 2 || found == 3)
                        {
                            yield return new CodeInstruction(OpCodes.Call, getSearchTermMethod);
                        }
                    }
                    yield return instruction;
                }
                if (found != 4) Main.Error("transpiler CharacterInformationPanel.Refresh");
            }
        }
    }
}

//private static void Prefix(CharacterInformationPanel __instance,
//                   GuiLabel ___raceLabel,
//                   Image ___raceImage,
//                   ScrollRect ___raceFeaturesScrollRect,
//                   GuiLabel ___raceDescription,
//                   RectTransform ___raceFeaturesTable,
//                   GuiLabel ___classLabel,
//                   Image ___classImage,
//                   RectTransform ___classBadgesTable,
//                   GameObject ___classBadgePrefab,
//                   GuiLabel ___classDescription,
//                   ScrollRect ___classFeaturesScrollRect,
//                   RectTransform ___classFeaturesTable,
//                   GuiLabel ___backgroundLabel,
//                   Image ___backgroundImage,
//                   GuiLabel ___backgroundDescription,
//                   ScrollRect ___backgroundFeaturesScrollRect,
//                   RectTransform ___backgroundFeaturesTable,
//                   GameObject ___featurePrefab,
//                   List<FeatureUnlockByLevel> ___filteredFeatures,
//                   List<FeatureUnlockByLevel> ___raceFeatures,
//                   List<FeatureUnlockByLevel> ___classFeatures,
//                   List<FeatureUnlockByLevel> ___backgroundFeatures,
//                   List<BaseDefinition> ___badgeDefinitions)