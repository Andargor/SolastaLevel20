using SolastaModApi;
using SolastaModApi.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using static SolastaModApi.DatabaseHelper.CharacterClassDefinitions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionFeatureSets;
using static SolastaLevel20.Models.Features.ProficiencyRogueBlindSenseBuilder;
using static SolastaLevel20.Models.Features.ProficiencyRogueSlipperyMindBuilder;
using static SolastaLevel20.Models.Features.FeatureRogueReliableTalentBuilder;

namespace SolastaLevel20.Models.Classes
{
    class RogueBuilder
    {
        public static void Load()
        {
            // Unofficial Fixes does this as well so we need to protect against each other
            if (!Rogue.FeatureUnlocks.Where(fu => fu.Level == 10).Any(fu => fu.FeatureDefinition == FeatureSetAbilityScoreChoice))
            {
                Rogue.FeatureUnlocks.Add(new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 10));
            }

            Rogue.FeatureUnlocks.AddRange(new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(FeatureRogueReliableTalent, 11),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                // TODO 13: Roguish Archetype Feature
                new FeatureUnlockByLevel(ProficiencyRogueBlindSense, 14),
                new FeatureUnlockByLevel(ProficiencyRogueSlipperyMind, 15),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                // TODO 17: Roguish Archetype Feature
                // TODO 18: Elusive
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19)
                // TODO 20: Stroke of Luck
            });
            // In case TA adds levels 11-20 later on, clear them out. If that happens we can delete this section.
            DatabaseHelper.FeatureDefinitionAdditionalDamages.AdditionalDamageRogueSneakAttack.DiceByRankTable.RemoveAll(x => x.Rank > 10);
            DatabaseHelper.FeatureDefinitionAdditionalDamages.AdditionalDamageRogueSneakAttack.DiceByRankTable.AddRange(new List<DiceByRank>() {
                BuildDiceByRank(11, 6),
                BuildDiceByRank(12, 6),
                BuildDiceByRank(13, 7),
                BuildDiceByRank(14, 7),
                BuildDiceByRank(15, 8),
                BuildDiceByRank(16, 8),
                BuildDiceByRank(17, 9),
                BuildDiceByRank(18, 9),
                BuildDiceByRank(19, 10),
                BuildDiceByRank(20, 10),
            }); ;
        }
        private static DiceByRank BuildDiceByRank(int rank, int dice)
        {
            DiceByRank diceByRank = new DiceByRank();
            diceByRank.SetField("rank", rank);
            diceByRank.SetField("diceNumber", dice);
            return diceByRank;
        }
    }
}