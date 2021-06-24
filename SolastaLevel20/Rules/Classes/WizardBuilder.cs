using System.Collections.Generic;
using static SolastaModApi.DatabaseHelper.CharacterClassDefinitions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionAttributeModifiers;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionCastSpells;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionFeatureSets;
// using static SolastaModApi.DatabaseHelper.SpellDefinitions;
using static SolastaModApi.DatabaseHelper.SpellListDefinitions;
using static SolastaModApi.Extensions.FeatureDefinitionCastSpellExtensions;
using static SolastaModApi.Extensions.SpellListDefinitionExtensions;

namespace SolastaLevel20.Rules.Classes
{
    public static class WizardBuilder
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
            Wizard.FeatureUnlocks.AddRange(new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                // TODO 14: Overchannel
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                // TODO 18: Spell Mastery
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19)
                // TODO 20: Signature Spells
            });

            // add missing spell slots
            foreach (var slot in CastSpellWizard.SlotsPerLevels)
            {
                slot.Slots = Slots[slot.Level - 1];
            }

            CastSpellWizard.SetSpellCastingLevel(Slots[0].Count);
            SpellListWizard.SetMaxSpellLevel(Slots[0].Count);
            SpellListWizardGreenmage.SetMaxSpellLevel(Slots[0].Count);
            SpellListShockArcanist.SetMaxSpellLevel(Slots[0].Count);
        }
    }
}