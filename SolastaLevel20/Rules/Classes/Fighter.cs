using System;
using System.Collections.Generic;
using HarmonyLib;

namespace SolastaLevel20.Rules.Classes
{
    public static class Fighter
    {
        static CharacterClassDefinition _Fighter => DatabaseRepository.GetDatabase<CharacterClassDefinition>().TryGetElement("Fighter", "");
        static FeatureDefinitionAttributeModifier AttributeModifierFighterExtraAttack => DatabaseRepository.GetDatabase<FeatureDefinitionAttributeModifier>().TryGetElement("AttributeModifierFighterExtraAttack", "");
        static FeatureDefinitionAttributeModifier AttributeModifierFighterIndomitable2 => DatabaseRepository.GetDatabase<FeatureDefinitionAttributeModifier>().TryGetElement("AttributeModifierFighterIndomitable2", "");
        static FeatureDefinitionAttributeModifier AttributeModifierFighterIndomitable3 => DatabaseRepository.GetDatabase<FeatureDefinitionAttributeModifier>().TryGetElement("AttributeModifierFighterIndomitable3", "");
        static FeatureDefinitionFeatureSet FeatureSetAbilityScoreChoice => DatabaseRepository.GetDatabase<FeatureDefinitionFeatureSet>().TryGetElement("FeatureSetAbilityScoreChoice", "");
        static FeatureDefinitionFeatureSet PowerFighterActionSurge => DatabaseRepository.GetDatabase<FeatureDefinitionFeatureSet>().TryGetElement("PowerFighterActionSurge", "");

        public static void Load()
        {
            List<FeatureUnlockByLevel> features = new List<FeatureUnlockByLevel> {
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
            _Fighter.FeatureUnlocks.AddRange(features);
        }
    }
}