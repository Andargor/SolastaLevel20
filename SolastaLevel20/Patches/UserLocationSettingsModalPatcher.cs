using TMPro;
using HarmonyLib;

namespace SolastaLevel20.Patches
{
    class UserLocationSettingsModalPatcher
    {
        [HarmonyPatch(typeof(UserLocationSettingsModal), "OnMinLevelEndEdit")]
        internal static class UserLocationSettingsModalPatcher_OnMinLevelEndEdit_Patch
        {
            internal static bool Prefix(TMP_InputField ___minLevelInputField, int ___minLevel)
            {
                if (!int.TryParse(___minLevelInputField.text, out int result))
                    result = 1;
                else if (result < 0)
                    result = 1;
                else if (result > Main.MAX_LEVEL)
                    result = Main.MAX_LEVEL;
                ___minLevelInputField.text = result.ToString();
                ___minLevel = result;
                return false;
            }
        }

        [HarmonyPatch(typeof(UserLocationSettingsModal), "OnMaxLevelEndEdit")]
        internal static class UserLocationSettingsModalPatcher_OnMaxLevelEndEdit_Patch
        {
            internal static bool Prefix(TMP_InputField ___maxLevelInputField, int ___maxLevel)
            {
                if (!int.TryParse(___maxLevelInputField.text, out int result))
                    result = 1;
                else if (result < 0)
                    result = 1;
                else if (result > Main.MAX_LEVEL)
                    result = Main.MAX_LEVEL;
                ___maxLevelInputField.text = result.ToString();
                ___maxLevel = result;
                return false;
            }
        }
    }
}