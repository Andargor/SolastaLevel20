using HarmonyLib;
using System.Linq;
using static SolastaLevel20.Rules.Features.FeatureRogueReliableTalentBuilder;

namespace SolastaLevel20.Patches
{
    [HarmonyPatch(typeof(RulesetCharacter), "VerifyAbilityCheck")]
    internal static class RulesetCharacterVerifyAbilityCheckPatcher
    {
        public static void Prefix(RulesetCharacter __instance, ref int diceRoll, string proficiencyName)
        {
            var hero = __instance as RulesetCharacterHero;
           
            if (hero == null) { return; }
            if (!hero.ClassesAndLevels.Keys.Any(k => k.Name == RuleDefinitions.RogueClass)) { return; }
            if (!hero.FeaturesToBrowse.OfType<IDieRollModificationProvider>().Any(f => (BaseDefinition)f == FeatureRogueReliableTalent)) { return; }

            if (diceRoll < 10 && IsProficient())
            {
                Main.Log($"Increasing die roll from {diceRoll} to 10.");

                // TODO: add something to log window? "Rogue's reliable talent converted a roll of 'x' to '10'.

                diceRoll = 10;
            }

            bool IsProficient()
            {
                return hero.ToolTypeProficiencies.Contains(proficiencyName) 
                    || hero.SkillProficiencies.Contains(proficiencyName) 
                    || hero.ExpertiseProficiencies.Contains(proficiencyName);
            }
        }
    }
}