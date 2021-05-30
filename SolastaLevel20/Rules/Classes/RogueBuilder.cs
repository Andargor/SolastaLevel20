using System.Collections.Generic;
using static SolastaModApi.DatabaseHelper.CharacterClassDefinitions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionFeatureSets;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionAdditionalActions;

namespace SolastaLevel20.Rules.Classes
{
    class RogueBuilder
    {
        public static void Load()
        {
            List<FeatureUnlockByLevel> features = new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 10),
                // TODO 11: Reliable Talent 
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                // TODO 13: Roguish Archetype Feature
                // TODO 14: Blindsense
                // TODO 15: Slippery Minds
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                // TODO 17: Roguish Archetype Feature
                // TODO 18: Elusive
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19)
                // TODO 20: Stroke of Luck
            };

            Rogue.FeatureUnlocks.AddRange(features);
        }
    }
}