using System.Collections.Generic;
using static SolastaModApi.DatabaseHelper.CharacterClassDefinitions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionAttributeModifiers;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionCastSpells;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionFeatureSets;
// using static SolastaModApi.DatabaseHelper.SpellDefinitions;
using static SolastaModApi.DatabaseHelper.SpellListDefinitions;
using static SolastaModApi.Extensions.SpellListDefinitionExtensions;
using static SolastaModApi.Extensions.FeatureDefinitionCastSpellExtensions;
using static SolastaLevel20.Rules.Features.PowerClericTurnUndeadBuilder;

namespace SolastaLevel20.Rules.Classes
{
    public static class ClericBuilder
    {
        private static readonly List<List<int>> Slots = new List<List<int>>
        {
            new List<int> {2,0,0,0,0},
            new List<int> {3,0,0,0,0},
            new List<int> {4,2,0,0,0},
            new List<int> {4,3,0,0,0},
            new List<int> {4,3,2,0,0},
            new List<int> {4,3,3,0,0},
            new List<int> {4,3,3,1,0},
            new List<int> {4,3,3,2,0},
            new List<int> {4,3,3,3,1},
            new List<int> {4,3,3,3,2},
            new List<int> {4,3,3,3,2},
            new List<int> {4,3,3,3,2},
            new List<int> {4,3,3,3,2},
            new List<int> {4,3,3,3,2},
            new List<int> {4,3,3,3,2},
            new List<int> {4,3,3,3,2},
            new List<int> {4,3,3,3,2},
            new List<int> {4,3,3,3,3},
            new List<int> {4,3,3,3,3},
            new List<int> {4,3,3,3,3},
        };

        public static void Load()
        {
            // add missing progression
            Cleric.FeatureUnlocks.AddRange(new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(PowerClericTurnUndead11, 11),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                new FeatureUnlockByLevel(PowerClericTurnUndead14, 14),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                new FeatureUnlockByLevel(PowerClericTurnUndead17, 17),
                new FeatureUnlockByLevel(AttributeModifierClericChannelDivinityAdd, 18),
                // TODO 17: Divine Domain Feature
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19)
                // TODO 20: Divine Intervention Improvement
            });

            // add missing spell slots
            foreach (var slot in CastSpellCleric.SlotsPerLevels)
            {
                slot.Slots = Slots[slot.Level - 1];
            }
            CastSpellCleric.SetSpellCastingLevel(Slots[0].Count);
            SpellListCleric.SetMaxSpellLevel(Slots[0].Count);
        }
    }
}