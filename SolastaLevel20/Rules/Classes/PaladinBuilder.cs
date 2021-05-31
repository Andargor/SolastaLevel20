using System.Collections.Generic;
using static SolastaModApi.DatabaseHelper.CharacterClassDefinitions;
using static SolastaModApi.DatabaseHelper.SpellListDefinitions;
using static SolastaModApi.DatabaseHelper.SpellDefinitions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionFeatureSets;
using static SolastaLevel20.Rules.Features.AdditionalDamagePaladinImprovedDivineSmiteBuilder;

namespace SolastaLevel20.Rules.Classes
{
    public static class PaladinBuilder
    {
        public static void Load()
        {
            var features = new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(AdditionalDamagePaladinImprovedDivineSmite, 11),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                // TODO 14: Cleansing Touch
                // TODO 15: Sacred Oath Feature
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                // TODO 18: Aura Improvements
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19)
                // TODO 20: Sacred Oath Feature
            };

            Paladin.FeatureUnlocks.AddRange(features);

            // add missing spells to Paladin
            var spellListPaladin4th = SpellListPaladin.SpellsByLevel.Find(x => x.Level == 4);
            spellListPaladin4th.Spells.AddRange(new List<SpellDefinition>
                {
                    // Banishement
                    DeathWard
                });

            //var spellListPaladin5th = SpellListPaladin.SpellsByLevel.Find(x => x.Level == 5);
            //spellListPaladin5th.Spells.AddRange(new List<SpellDefinition>
            //    {
            //        // Dispel Evil and Good
            //        // Raise Dead
            //    });
        }
    }
}