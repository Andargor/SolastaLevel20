using System.Collections.Generic;
using static SolastaModApi.DatabaseHelper.CharacterClassDefinitions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionFeatureSets;

namespace SolastaLevel20.Rules.Classes
{
    public static class RangerBuilder
    {
        public static void Load()
        {
            List<FeatureUnlockByLevel> features = new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                // TODO 13: Ranger Archetype Feature
                // TODO 14: Favored Enemy Improvement
                // TODO 14: Vanish
                // TODO 15: Ranger Archetype Feature
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                // TODO 18: Feral Senses
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19),
                // TODO 20: Foe Slayer
            };

            Ranger.FeatureUnlocks.AddRange(features);
        }
    }
}
