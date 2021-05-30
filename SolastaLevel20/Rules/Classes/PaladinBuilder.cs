using System.Collections.Generic;
using static SolastaLevel20.Rules.Features.AdditionalDamagePaladinImprovedDivineSmiteBuilder;
using static SolastaModApi.DatabaseHelper.CharacterClassDefinitions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionFeatureSets;

namespace SolastaLevel20.Rules.Classes
{
    public static class PaladinBuilder
    {
        public static void Load()
        {
            var features = new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(AdditionalDamagePaladinImprovedDivineSmite.Value, 11),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                // TODO 14: Cleansing Touch
                // TODO 15: Sacred Oath Feature
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                // TODO 18: Aura Improvements
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19)
                // TODO 20: Sacred Oath Feature
            };

            Paladin.FeatureUnlocks.AddRange(features);
        }
    }
}
