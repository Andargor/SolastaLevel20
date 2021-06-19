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
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var code = new List<CodeInstruction>(instructions);
                code.Find(x => x.opcode.Name == "ldc.i4.s" && Convert.ToInt32(x.operand) == Main.GAME_MAX_LEVEL).operand = Main.MOD_MAX_LEVEL;
                return code;
            }

            static void Postfix(CharactersPanel __instance, Button ___characterCheckerButton, Button ___exportPdfButton, List<CharacterPlateToggle> ___characterPlates, int ___selectedPlate)
            {

                var characterLevel = (___selectedPlate >= 0) ? ___characterPlates[___selectedPlate].GuiCharacter.CharacterLevel : Main.MOD_MIN_LEVEL;
                ___exportPdfButton.gameObject.SetActive(characterLevel > Main.MOD_MIN_LEVEL);
                ___characterCheckerButton.gameObject.SetActive(true);
            }
        }

        [HarmonyPatch(typeof(CharactersPanel), "OnExportPdfCb")]
        internal static class CharactersPanel_OnExportPdfCb_Patch
        {
            static void Postfix(CharactersPanel __instance, List<CharacterPlateToggle> ___characterPlates, int ___selectedPlate)
            {
                ICharacterPoolService service = ServiceRepository.GetService<ICharacterPoolService>();
                RulesetCharacterHero hero = (RulesetCharacterHero)null;
                RulesetCharacterHero.Snapshot snapshot = (RulesetCharacterHero.Snapshot)null;
                string filename = ___characterPlates[___selectedPlate].Filename;

                service.LoadCharacter(filename, out hero, out snapshot);
                var exp = hero.ExperienceGained;
                var characterLevel = hero.GetAttribute("CharacterLevel").CurrentValue.ToString();
                //if (characterLevel == "1")
                //    __instance.OnNewCharacterCb();
                //else
                //{
                hero.RemoveClassLevel();
                hero.ExperienceGained = exp;
                var featuresToRemove = hero.ActiveFeatures.Where(x => x.Key.EndsWith(characterLevel)).Select(x => x.Key);
                foreach (var key in featuresToRemove)
                    hero.ActiveFeatures.Remove(key);
                hero.RefreshAll();
                hero.FillSnapshot(snapshot, true);
                service.Pool.Remove(filename);
                service.SaveCharacter(hero, true);
                //}
            }
        }        
    }
}