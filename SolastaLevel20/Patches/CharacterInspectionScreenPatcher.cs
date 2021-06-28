using HarmonyLib;
using static SolastaLevel20.Settings;

namespace SolastaLevel20.Patches
{
    class CharacterInspectionScreenPatcher
    {
        [HarmonyPatch(typeof(CharacterInspectionScreen), "HandleInput")]
        internal static class HeroDefinitions_MaxHeroExperience_Patch
        {
            internal static void Postfix(InputCommands.Id command)
            {
                switch (command)
                {
                    case CTRL_SHIFT_LEFT:
                        Gui.GuiService.ShowMessage(
                            MessageModal.Severity.Attention2,
                            "", "LEFT ARROW",
                            "Message/&MessageYesTitle", "Message/&MessageNoTitle",
                            null, null);
                        break;

                    case CTRL_SHIFT_RIGHT:
                        Gui.GuiService.ShowMessage(
                            MessageModal.Severity.Attention2,
                            "", "RIGHT ARROW",
                            "Message/&MessageYesTitle", "Message/&MessageNoTitle",
                            null, null);
                        break;
                }
            }
        }

        [HarmonyPatch(typeof(CharacterInspectionScreen), "Load")]
        internal static class HeroDefinitions_Load_Patch
        {
            internal static void Postfix()
            {
                var x = 0;
            }
        }
    }
}