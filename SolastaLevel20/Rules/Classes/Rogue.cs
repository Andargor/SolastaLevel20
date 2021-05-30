using System.Collections.Generic;

namespace SolastaLevel20.Rules.Classes
{
    class Rogue
    {
        static CharacterClassDefinition _Rogue => DatabaseRepository.GetDatabase<CharacterClassDefinition>().TryGetElement("Rogue", "8ae0dcdf1cf0a264c8198e0ca715eaf3");
        static FeatureDefinitionFeatureSet FeatureSetAbilityScoreChoice => DatabaseRepository.GetDatabase<FeatureDefinitionFeatureSet>().TryGetElement("FeatureSetAbilityScoreChoice", "0f791ae5a6ffdc742be023184a115e1d");

        public static void Load()
        {
            List<FeatureUnlockByLevel> features = new List<FeatureUnlockByLevel> {
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
            _Rogue.FeatureUnlocks.AddRange(features);
        }
    }
}