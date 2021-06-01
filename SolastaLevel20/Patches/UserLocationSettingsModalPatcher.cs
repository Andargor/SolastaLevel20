using TMPro;
using System.Collections.Generic;
using HarmonyLib;

namespace SolastaLevel20.Patches
{
    class UserLocationSettingsModalPatcher
    {
        //[HarmonyPatch(typeof(UserLocationSettingsModal), "OnMinLevelEndEdit")]
        //internal static class UserLocationSettingsModal_OnMinLevelEndEdit_Patch
        //{
        //    internal static bool Prefix(TMP_InputField ___minLevelInputField, int ___minLevel)
        //    {
        //        if (!int.TryParse(___minLevelInputField.text, out int result))
        //            result = 1;
        //        else if (result < 0)
        //            result = 1;
        //        else if (result > Main.MOD_MAX_LEVEL)
        //            result = Main.MOD_MAX_LEVEL;
        //        ___minLevelInputField.text = result.ToString();
        //        ___minLevel = result;
        //        return false;
        //    }
        //}

        [HarmonyPatch(typeof(UserLocationSettingsModal), "OnMinLevelEndEdit")]
        public class UserLocationSettingsModal_OnMinLevelEndEdit_Patch
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var code = new List<CodeInstruction>(instructions);
                var opcodes = code.FindAll(x => x.opcode.Name == "ldc.i4.s" && (int) x.operand == Main.GAME_MAX_LEVEL);
                foreach (var opcode in opcodes)
                    opcode.operand = Main.MOD_MAX_LEVEL;

                return code;
            }
        }

        //[HarmonyPatch(typeof(UserLocationSettingsModal), "OnMaxLevelEndEdit")]
        //internal static class UserLocationSettingsModal_OnMaxLevelEndEdit_Patch
        //{
        //    internal static bool Prefix(TMP_InputField ___maxLevelInputField, int ___maxLevel)
        //    {
        //        if (!int.TryParse(___maxLevelInputField.text, out int result))
        //            result = 1;
        //        else if (result < 0)
        //            result = 1;
        //        else if (result > Main.MOD_MAX_LEVEL)
        //            result = Main.MOD_MAX_LEVEL;
        //        ___maxLevelInputField.text = result.ToString();
        //        ___maxLevel = result;
        //        return false;
        //    }
        //}

        [HarmonyPatch(typeof(UserLocationSettingsModal), "OnMaxLevelEndEdit")]
        public class UserLocationSettingsModal_OnMaxLevelEndEdit_Patch
        {
            static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                var code = new List<CodeInstruction>(instructions);
                var opcodes = code.FindAll(x => x.opcode.Name == "ldc.i4.s" && (int) x.operand == Main.GAME_MAX_LEVEL);
                foreach (var opcode in opcodes)
                    opcode.operand = Main.MOD_MAX_LEVEL;

                return code;
            }
        }
    }
}