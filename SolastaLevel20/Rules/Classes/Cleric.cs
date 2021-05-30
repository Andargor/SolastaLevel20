using System.Collections.Generic;
using static SolastaLevel20.Rules.Features.PowerClericTurnUndeadBuilder;
using static SolastaModApi.DatabaseHelper.CharacterClassDefinitions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionFeatureSets;

namespace SolastaLevel20.Rules.Classes
{
    public static class ClericBuilder
    {
        public static void Load()
        {
            var features = new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(PowerClericTurnUndead11.Value, 11),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                new FeatureUnlockByLevel(PowerClericTurnUndead14.Value, 14),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                new FeatureUnlockByLevel(PowerClericTurnUndead17.Value, 17),
                // TODO 17: Divine Domain Feature
                // TODO 18: Channel Divinity (3)
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19)
                // TODO 20: Divine Intervention Improvement
            };

            Cleric.FeatureUnlocks.AddRange(features);
        }
    }
}