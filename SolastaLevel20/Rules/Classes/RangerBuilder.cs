using System.Collections.Generic;
using static SolastaModApi.DatabaseHelper.CharacterClassDefinitions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionCastSpells;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionFeatureSets;
using static SolastaModApi.DatabaseHelper.SpellDefinitions;
using static SolastaModApi.DatabaseHelper.SpellListDefinitions;
using static SolastaModApi.Extensions.SpellListDefinitionExtensions;
using static SolastaModApi.Extensions.FeatureDefinitionCastSpellExtensions;
using static SolastaLevel20.Rules.Features.ActionAffinityRangerVanishActionBuilder;

namespace SolastaLevel20.Rules.Classes
{
    public static class RangerBuilder
    {
        private static readonly List<List<int>> Slots = new List<List<int>>
        {
            new List<int> {0,0,0,0},
            new List<int> {2,0,0,0},
            new List<int> {3,0,0,0},
            new List<int> {3,0,0,0},
            new List<int> {4,2,0,0},
            new List<int> {4,2,0,0},
            new List<int> {4,3,0,0},
            new List<int> {4,3,0,0},
            new List<int> {4,3,2,0},
            new List<int> {4,3,2,0},
            new List<int> {4,3,3,0},
            new List<int> {4,3,3,0},
            new List<int> {4,3,3,1},
            new List<int> {4,3,3,1},
            new List<int> {4,3,3,2},
            new List<int> {4,3,3,2},
            new List<int> {4,3,3,3},
            new List<int> {4,3,3,3},
            new List<int> {4,3,3,3},
            new List<int> {4,3,3,3},
        };

        public static void Load()
        {
            // add missing progression
            Ranger.FeatureUnlocks.AddRange(new List<FeatureUnlockByLevel> {
                // TODO 11: Ranger Archetype Feature
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                new FeatureUnlockByLevel(AdditionalDamageRangerFavoredEnemyChoice, 14),
                new FeatureUnlockByLevel(ActionAffinityRangerVanishAction, 14),
                // TODO 15: Ranger Archetype Feature
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                // TODO 18: Feral Senses
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19),
                // TODO 20: Foe Slayer
            });

            // add missing spell slots
            foreach (var slot in CastSpellRanger.SlotsPerLevels)
            {
                slot.Slots = Slots[slot.Level - 1];
            }
            CastSpellRanger.SetSpellCastingLevel(Slots.Count);
            SpellListRanger.SetMaxSpellLevel(SpellListRanger.SpellsByLevel.Count);

            // add Ranger 4th level spells
            SpellListRanger.SpellsByLevel.RemoveAll(x => x.Level == 4);
            SpellListRanger.SpellsByLevel.Add(new SpellListDefinition.SpellsByLevelDuplet
            {
                Level = 4,
                Spells = new List<SpellDefinition>
                {
                    ConjureElemental,
                    FreedomOfMovement,
                    Stoneskin
                }
            });
        }
    }
}