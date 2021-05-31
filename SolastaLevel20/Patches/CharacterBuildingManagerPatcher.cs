using System.Collections.Generic;
using HarmonyLib;

namespace SolastaLevel20.Patches
{
    class CharacterBuildingManagerPatcher
    {
        [HarmonyPatch(typeof(CharacterBuildingManager), "CreateCharacterFromTemplate")]
        public class CharacterBuildingManager_CreateCharacterFromTemplate_Patch
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var code = new List<CodeInstruction>(instructions);
                code[4].operand = Main.MAX_LEVEL;
                return code;
            }
        }
    }
}