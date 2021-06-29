using HarmonyLib;
using SolastaLevel20.Models.Classes;
using static SolastaLevel20.Settings;
using static SolastaLevel20.Models.MultiClass;

namespace SolastaLevel20.Patches
{
    class GameManagerPatcher
    {
        internal static void FixExperienceTable()
        {
            int[] experienceThresholds = new int[21];
            experienceThresholds[MOD_MAX_LEVEL] = MAX_CHARACTER_EXPERIENCE;
            for (var ix = 0; ix < MOD_MAX_LEVEL; ix++)
                experienceThresholds[ix] = RuleDefinitions.ExperienceThresholds[ix];
        }

        [HarmonyPatch(typeof(GameManager), "BindPostDatabase")]
        internal static class GameManager_BindPostDatabase_Patch
        {
            internal static void Postfix()
            {
                //ForceDeityOnAllClasses();
                FixExperienceTable();

                ClericBuilder.Load();
                FighterBuilder.Load();
                PaladinBuilder.Load();
                RangerBuilder.Load();
                RogueBuilder.Load();
                WizardBuilder.Load();

                //ServiceRepository.GetService<IInputService>().RegisterCommand(CTRL_SHIFT_RIGHT, 275, 304, 306, -1, -1, -1);
                //ServiceRepository.GetService<IInputService>().RegisterCommand(CTRL_SHIFT_LEFT, 276, 304, 306, -1, -1, -1);
            }
        }
    }
}