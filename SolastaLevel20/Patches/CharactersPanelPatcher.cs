using System.Collections.Generic;
using UnityEngine.UI;
using HarmonyLib;

namespace SolastaLevel20.Patches
{
    class CharactersPanelPatcher
    {
        //[HarmonyPatch(typeof(CharactersPanel), "Refresh")]
        //internal static class CharactersPanel_Refresh_Patch
        //{
        //    internal static void Postfix(CharactersPanel __instance, Button ___levelUpButton, int ___selectedPlate, List<CharacterPlateToggle> ___characterPlates)
        //    {
        //        ___levelUpButton.interactable = ___selectedPlate >= 0 && ___selectedPlate < ___characterPlates.Count && ___characterPlates[___selectedPlate].GuiCharacter.CharacterLevel < Main.MAX_LEVEL;
        //    }
        //}

        [HarmonyPatch(typeof(CharactersPanel), "Refresh")]
        internal static class CharactersPanel_Refresh_Patch
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var code = new List<CodeInstruction>(instructions);
                code.Find(x => x.opcode.Name == "ldc.i4.s" && x.operand.ToString() == "10").operand = 20;
                return code;
            }
        }
    }
}