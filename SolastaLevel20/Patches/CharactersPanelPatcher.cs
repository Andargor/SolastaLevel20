using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using HarmonyLib;

namespace SolastaLevel20.Patches
{
    class CharactersPanelPatcher
    {
        [HarmonyPatch(typeof(CharactersPanel), "Refresh")]
        internal static class CharactersPanel_Refresh_Patch
        {
            internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var code = new List<CodeInstruction>(instructions);
                code.Find(x => x.opcode.Name == "ldc.i4.s" && Convert.ToInt32(x.operand) == Main.GAME_MAX_LEVEL).operand = Main.MOD_MAX_LEVEL;
                return code;
            }

            internal static void Postfix(CharactersPanel __instance, Button ___characterCheckerButton, Button ___exportPdfButton, List<CharacterPlateToggle> ___characterPlates, int ___selectedPlate)
            {

                var characterLevel = (___selectedPlate >= 0) ? ___characterPlates[___selectedPlate].GuiCharacter.CharacterLevel : Main.MOD_MIN_LEVEL;
                ___exportPdfButton.gameObject.SetActive(characterLevel > Main.MOD_MIN_LEVEL);
                ___characterCheckerButton.gameObject.SetActive(true);
            }
        }

        [HarmonyPatch(typeof(CharactersPanel), "OnExportPdfCb")]
        internal static class CharactersPanel_OnExportPdfCb_Patch
        {
            internal static void Postfix(CharactersPanel __instance, List<CharacterPlateToggle> ___characterPlates, int ___selectedPlate)
            {
                var characterPoolService = ServiceRepository.GetService<ICharacterPoolService>();
                var characterBuildingService = ServiceRepository.GetService<ICharacterBuildingService>();

                RulesetCharacterHero hero = (RulesetCharacterHero)null;
                RulesetCharacterHero.Snapshot snapshot = (RulesetCharacterHero.Snapshot)null;
                string filename = ___characterPlates[___selectedPlate].Filename;
                characterPoolService.LoadCharacter(filename, out hero, out snapshot);
                var experienceGained = hero.ExperienceGained;

                characterBuildingService.CreateNewCharacter();
                AccessTools.Field(characterBuildingService.GetType(), "heroCharacter").SetValue(characterBuildingService, hero);
                characterBuildingService.UnassignLastClassLevel(true);
                hero.RefreshAll();
                hero.AutoPrepareSpells(true);
                hero.ExperienceGained = experienceGained;
                var characterLevel = hero.GetAttribute("CharacterLevel").CurrentValue.ToString();
                var featuresToRemove = hero.ActiveFeatures.Where(x => x.Key.EndsWith(characterLevel)).Select(x => x.Key);
                foreach (var key in featuresToRemove)
                {
                    hero.ActiveFeatures.Remove(key);
                }
                hero.RefreshAll();
                hero.FillSnapshot(snapshot, true);

                characterPoolService.Pool.Remove(filename);
                characterPoolService.SaveCharacter(hero, true);
            }
        }        
    }
}