using System;
using System.Collections.Generic;
using HarmonyLib;

namespace SolastaLevel20.Rules.Classes
{
    public static class Paladin
    {
        public static CharacterClassDefinition _Paladin => DatabaseRepository.GetDatabase<CharacterClassDefinition>().TryGetElement("Paladin", "");
        static FeatureDefinitionFeatureSet FeatureSetAbilityScoreChoice => DatabaseRepository.GetDatabase<FeatureDefinitionFeatureSet>().TryGetElement("FeatureSetAbilityScoreChoice", "");
        static FeatureDefinitionAdditionalDamage AdditionalDamagePaladinImprovedDivineSmite => DatabaseRepository.GetDatabase<FeatureDefinitionAdditionalDamage>().TryGetElement("AdditionalDamagePaladinImprovedDivineSmite", "");

        public static void Load()
        {
            List<FeatureUnlockByLevel> features = new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(AdditionalDamagePaladinImprovedDivineSmite, 11),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                // TODO 14: Cleansing Touch
                // TODO 15: Sacred Oath Feature
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                // TODO 18: Aura Improvements
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19)
                // TODO 20: Sacred Oath Feature
            };
            _Paladin.FeatureUnlocks.AddRange(features);
        }
    }
}
