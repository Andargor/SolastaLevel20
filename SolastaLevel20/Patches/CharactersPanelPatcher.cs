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
                code.Find(x => x.opcode.Name == "ldc.i4.s" && x.operand.ToString() == Main.GAME_MAX_LEVEL).operand = Main.MOD_MAX_LEVEL;
                return code;
            }

            static void Postfix(CharactersPanel __instance, Button ___exportPdfButton, List<CharacterPlateToggle> ___characterPlates, int ___selectedPlate)
            {

                var characterLevel = (___selectedPlate >= 0) ? ___characterPlates[___selectedPlate].GuiCharacter.CharacterLevel : 1;
                ___exportPdfButton.gameObject.SetActive(characterLevel > 1);
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
                hero.RemoveClassLevel();
                hero.ExperienceGained = exp;
                foreach (var key in hero.ActiveFeatures.Where(x => x.Key.EndsWith(characterLevel)).Select(x => x.Key).ToList())
                    hero.ActiveFeatures.Remove(key);
                hero.RefreshAll();
                hero.FillSnapshot(snapshot, true);
                service.Pool.Remove(filename);
                service.SaveCharacter(hero, true);
                //___characterPlates[___selectedPlate].Bind(
                //    filename,
                //    snapshot,
                //    ___characterPlates[___selectedPlate].OnPlateSelected,
                //    ___characterPlates[___selectedPlate].OnPlateDoubleClicked,
                //    ___characterPlates[___selectedPlate].OnPlateDeleted,
                //    true);
            }
        }        
    }
}