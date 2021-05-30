using System.Collections.Generic;
using static SolastaModApi.DatabaseHelper.CharacterClassDefinitions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionFeatureSets;

namespace SolastaLevel20.Rules.Classes
{
    public static class WizardBuilder
    {
        public static void Load()
        {
            List<FeatureUnlockByLevel> features = new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                // TODO 14: Overchannel
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                // TODO 18: Spell Mastery
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19)
                // TODO 20: Signature Spells
            };

            Wizard.FeatureUnlocks.AddRange(features);
        }
    }
}