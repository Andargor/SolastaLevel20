using System.Collections.Generic;

namespace SolastaLevel20.Rules.Classes
{
    public static class Ranger
    {
        static CharacterClassDefinition _Ranger => DatabaseRepository.GetDatabase<CharacterClassDefinition>().TryGetElement("Ranger", "d4cb9ea3b00ab6a4c9d3cd07aa199f40");
        static FeatureDefinitionFeatureSet FeatureSetAbilityScoreChoice => DatabaseRepository.GetDatabase<FeatureDefinitionFeatureSet>().TryGetElement("FeatureSetAbilityScoreChoice", "0f791ae5a6ffdc742be023184a115e1d");

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
            _Ranger.FeatureUnlocks.AddRange(features);
        }
    }
}
