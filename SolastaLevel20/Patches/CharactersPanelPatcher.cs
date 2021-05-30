using System.Collections.Generic;
using HarmonyLib;
using UnityEngine.UI;

namespace SolastaLevel20.Patches
{
    class CharactersPanelPatcher
    {
        [HarmonyPatch(typeof(CharactersPanel), "Refresh")]
        internal static class CharactersPanel_Refresh_Patch
        {
            internal static void Postfix(CharactersPanel __instance, Button ___levelUpButton, int ___selectedPlate, List<CharacterPlateToggle> ___characterPlates)
            {
                ___levelUpButton.interactable = ___selectedPlate >= 0 && ___selectedPlate < ___characterPlates.Count && ___characterPlates[___selectedPlate].GuiCharacter.CharacterLevel < Main.MAX_LEVEL;
            }
        }
    }
}