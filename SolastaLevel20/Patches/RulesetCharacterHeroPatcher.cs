using System;
using System.Collections.Generic;
using HarmonyLib;
using static SolastaLevel20.Settings;

namespace SolastaLevel20.Patches
{
    class RulesetCharacterHeroPatcher
    {
        [HarmonyPatch(typeof(RulesetCharacterHero), "RegisterAttributes")]
        internal static class RulesetCharacterHero_RegisterAttributes_Patch
        {
            internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var code = new List<CodeInstruction>(instructions);
                code.Find(x => x.opcode.Name == "ldc.i4.s" && Convert.ToInt32(x.operand) == GAME_MAX_LEVEL).operand = MOD_MAX_LEVEL;
                return code;
            }
        }

        [HarmonyPatch(typeof(RulesetCharacterHero), "PostLoad")]
        internal static class RulesetCharacterHero_PostLoad_Patch
        {
            internal static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var code = new List<CodeInstruction>(instructions);
                var opcodes = code.FindAll(x => x.opcode.Name == "ldc.i4.s" && Convert.ToInt32(x.operand) == GAME_MAX_LEVEL);
                foreach (var opcode in opcodes)
                {
                    opcode.operand = MOD_MAX_LEVEL;
                }
                return code;
            }
        }
    }
}