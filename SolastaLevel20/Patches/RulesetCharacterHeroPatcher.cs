﻿using System.Collections.Generic;
using HarmonyLib;

namespace SolastaLevel20.Patches
{
    class RulesetCharacterHeroPatcher
    {
        [HarmonyPatch(typeof(RulesetCharacterHero), "RegisterAttributes")]
        internal static class RulesetCharacterHero_RegisterAttributes_Patch
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