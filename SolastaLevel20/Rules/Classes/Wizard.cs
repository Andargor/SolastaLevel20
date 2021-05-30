using System.Collections.Generic;

namespace SolastaLevel20.Rules.Classes
{
    public static class Wizard
    {
        public static CharacterClassDefinition _Wizard => DatabaseRepository.GetDatabase<CharacterClassDefinition>().TryGetElement("Wizard", "a279003a65f95a64eb58fcc71463c734");
        static FeatureDefinitionFeatureSet FeatureSetAbilityScoreChoice => DatabaseRepository.GetDatabase<FeatureDefinitionFeatureSet>().TryGetElement("FeatureSetAbilityScoreChoice", "0f791ae5a6ffdc742be023184a115e1d");

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
            _Wizard.FeatureUnlocks.AddRange(features);
        }
    }
}