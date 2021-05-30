using HarmonyLib;
using System.Collections.Generic;

namespace SolastaLevel20.Rules.Classes
{
    public static class Cleric
    {
        static CharacterClassDefinition _Cleric => DatabaseRepository.GetDatabase<CharacterClassDefinition>().TryGetElement("Cleric", "");
        static FeatureDefinitionPower PowerClericTurnUndead11 => DatabaseRepository.GetDatabase<FeatureDefinitionPower>().TryGetElement("PowerClericTurnUndead11", "");
        static FeatureDefinitionPower PowerClericTurnUndead14 => DatabaseRepository.GetDatabase<FeatureDefinitionPower>().TryGetElement("PowerClericTurnUndead14", "");
        static FeatureDefinitionPower PowerClericTurnUndead17 => DatabaseRepository.GetDatabase<FeatureDefinitionPower>().TryGetElement("PowerClericTurnUndead17", "");
        static FeatureDefinitionFeatureSet FeatureSetAbilityScoreChoice => DatabaseRepository.GetDatabase<FeatureDefinitionFeatureSet>().TryGetElement("FeatureSetAbilityScoreChoice", "");

        public static void Load()
        {
            List<FeatureUnlockByLevel> features = new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(PowerClericTurnUndead11, 11),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                new FeatureUnlockByLevel(PowerClericTurnUndead14, 14),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                new FeatureUnlockByLevel(PowerClericTurnUndead17, 17),
                // TODO 17: Divine Domain Feature
                // TODO 18: Channel Divinity (3)
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19)
                // TODO 20: Divine Intervention Improvement
            };
            _Cleric.FeatureUnlocks.AddRange(features);
        }
    }
}