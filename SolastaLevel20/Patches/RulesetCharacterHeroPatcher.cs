using System.Collections.Generic;
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
                code.Find(x => x.opcode.Name == "ldc.i4.s" && (int) x.operand == Main.GAME_MAX_LEVEL).operand = Main.MOD_MAX_LEVEL;
                return code;
            }
        }
    }
}