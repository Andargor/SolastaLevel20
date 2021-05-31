using System.Collections.Generic;
using HarmonyLib;

namespace SolastaLevel20.Patches
{
    class RulesetCharacterHeroPatcher
    {
        [HarmonyPatch(typeof(RulesetCharacterHero), "RegisterAttributes")]
        public class RulesetCharacterHero_RegisterAttributes_Patch
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var code = new List<CodeInstruction>(instructions);
                /*
                 *      IL_0034: ldarg.0      // this
                 *      IL_0035: ldstr        "CharacterLevel"
                 *      IL_003a: callvirt     instance class RulesetAttribute RulesetEntity::RegisterAttribute(string)
                 *      IL_0040: ldc.i4.1
                 *      IL_0041: callvirt     instance void RulesetAttribute::set_BaseValue(int32)
                 *      IL_0047: ldc.i4.1
                 *      IL_0048: callvirt     instance void RulesetAttribute::set_MinValue(int32)
                 *      IL_004d: ldc.i4.s     10 // 0x0a
                 *      IL_004f: callvirt     instance void RulesetAttribute::set_MaxValue(int32)
                 * 
                 */
                code.Find(x => x.opcode.Name == "ldc.i4.s" && x.operand.ToString() == "10").operand = 20;
                return code;
            }
        }
    }
}