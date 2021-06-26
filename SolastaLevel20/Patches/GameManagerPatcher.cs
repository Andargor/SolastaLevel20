using HarmonyLib;
using SolastaLevel20.Rules.Classes;

namespace SolastaLevel20.Patches
{
    class GameManagerPatcher
    {
        internal static void FixExperienceTable()
        {
            int[] experienceThresholds = new int[21];
            experienceThresholds[Main.MOD_MAX_LEVEL] = Main.MAX_CHARACTER_EXPERIENCE;
            for (var ix = 0; ix < Main.MOD_MAX_LEVEL; ix++)
                experienceThresholds[ix] = RuleDefinitions.ExperienceThresholds[ix];
        }

        [HarmonyPatch(typeof(GameManager), "BindPostDatabase")]
        internal static class GameManager_BindPostDatabase_Patch
        {
            internal static void Postfix()
            {
                FixExperienceTable();
                ClericBuilder.Load();
                FighterBuilder.Load();
                PaladinBuilder.Load();
                RangerBuilder.Load();
                RogueBuilder.Load();
                WizardBuilder.Load();
            }
        }
    }
}