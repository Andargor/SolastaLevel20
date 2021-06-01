﻿using System.Collections.Generic;
using static SolastaModApi.DatabaseHelper.CharacterClassDefinitions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionCastSpells;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionFeatureSets;
using static SolastaModApi.DatabaseHelper.SpellDefinitions;
using static SolastaModApi.DatabaseHelper.SpellListDefinitions;
using static SolastaModApi.Extensions.SpellListDefinitionExtensions;
using static SolastaLevel20.Rules.Features.AdditionalDamagePaladinImprovedDivineSmiteBuilder;

namespace SolastaLevel20.Rules.Classes
{
    public static class PaladinBuilder
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
            Paladin.FeatureUnlocks.AddRange(new List<FeatureUnlockByLevel> {
                new FeatureUnlockByLevel(AdditionalDamagePaladinImprovedDivineSmite, 11),
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 12),
                // TODO 14: Cleansing Touch
                // TODO 15: Sacred Oath Feature
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 16),
                // TODO 18: Aura Improvements
                new FeatureUnlockByLevel(FeatureSetAbilityScoreChoice, 19)
                // TODO 20: Sacred Oath Feature
            });

            // add missing spell slots
            foreach (var slot in CastSpellPaladin.SlotsPerLevels)
            {
                slot.Slots = Slots[slot.Level - 1];
            }
            SpellListPaladin.SetMaxSpellLevel<SpellListDefinition>(Slots[0].Count);

            // add missing spells
            SpellListPaladin.SpellsByLevel.RemoveAll(x => x.Level == 4);
            SpellListPaladin.SpellsByLevel.Add(new SpellListDefinition.SpellsByLevelDuplet
            {
                Level = 4,
                Spells = new List<SpellDefinition>
                {
                    Banishment,
                    DeathWard
                }
            });
        }
    }
}