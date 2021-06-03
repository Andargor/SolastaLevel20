﻿using System.Collections.Generic;
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
        }
    }
}