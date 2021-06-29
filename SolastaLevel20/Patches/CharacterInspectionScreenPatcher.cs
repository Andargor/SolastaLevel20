using HarmonyLib;
using static SolastaLevel20.Settings;
using static SolastaLevel20.Models.ClassPicker;

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
                        PickPreviousClass();
                        break;

                    case CTRL_SHIFT_RIGHT:
                        PickNextClass();
                        break;
                }
            }
        }
    }
}