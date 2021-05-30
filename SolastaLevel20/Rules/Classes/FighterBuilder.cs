using System.Collections.Generic;
using static SolastaLevel20.Rules.Features.AttributeModifierFighterIndomitableBuilder;
using static SolastaModApi.DatabaseHelper.CharacterClassDefinitions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionAttributeModifiers;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionFeatureSets;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionPowers;

namespace SolastaLevel20.Rules.Classes
{
    public static class FighterBuilder
    {
        public static void Load()
        {
            var features = new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(AttributeModifierFighterExtraAttack, 11),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                new FeatureUnlockByLevel(AttributeModifierFighterIndomitable2, 13),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 14),
                // TODO 15: Martial Archetype Feature
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                new FeatureUnlockByLevel(PowerFighterActionSurge, 17),
                new FeatureUnlockByLevel(AttributeModifierFighterIndomitable3, 17),
                // TODO 18: Martial Archetype Feature
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19),
                new FeatureUnlockByLevel(AttributeModifierFighterExtraAttack, 20)
            };

            Fighter.FeatureUnlocks.AddRange(features);
        }
    }
}