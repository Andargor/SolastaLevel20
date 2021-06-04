﻿using TMPro;
using System.Collections.Generic;
using HarmonyLib;

namespace SolastaLevel20.Patches
{
    class UserLocationSettingsModalPatcher
    {
        [HarmonyPatch(typeof(UserLocationSettingsModal), "OnMinLevelEndEdit")]
        public class UserLocationSettingsModal_OnMinLevelEndEdit_Patch
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var code = new List<CodeInstruction>(instructions);
                var opcodes = code.FindAll(x => x.opcode.Name == "ldc.i4.s" && x.operand.ToString() == Main.GAME_MAX_LEVEL);
                foreach (var opcode in opcodes)
                    opcode.operand = Main.MOD_MAX_LEVEL;

                return code;
            }
        }

        [HarmonyPatch(typeof(UserLocationSettingsModal), "OnMaxLevelEndEdit")]
        public class UserLocationSettingsModal_OnMaxLevelEndEdit_Patch
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var code = new List<CodeInstruction>(instructions);
                var opcodes = code.FindAll(x => x.opcode.Name == "ldc.i4.s" && x.operand.ToString() == Main.GAME_MAX_LEVEL);
                foreach (var opcode in opcodes)
                    opcode.operand = Main.MOD_MAX_LEVEL;

                return code;
            }
        }
    }
}