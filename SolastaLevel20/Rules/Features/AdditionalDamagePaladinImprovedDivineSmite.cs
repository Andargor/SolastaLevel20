using HarmonyLib;
using System;
using System.Collections.Generic;

namespace SolastaLevel20.Rules.Features
{
    class AdditionalDamagePaladinImprovedDivineSmite
    {
        static FeatureDefinitionAdditionalDamage AdditionalDamagePaladinDivineSmite => DatabaseRepository.GetDatabase<FeatureDefinitionAdditionalDamage>().TryGetElement("AdditionalDamagePaladinDivineSmite", "");

        public static void Load()
        {
            FeatureDefinitionAdditionalDamage additionalDamagePaladinImprovedDivineSmite = UnityEngine.Object.Instantiate(AdditionalDamagePaladinDivineSmite);
            AccessTools.Field(additionalDamagePaladinImprovedDivineSmite.GetType(), "guid").SetValue(additionalDamagePaladinImprovedDivineSmite, "d7dbc91bbe4842648787691097f6b2a1");
            additionalDamagePaladinImprovedDivineSmite.name = "AdditionalDamagePaladinImprovedDivineSmite";
            additionalDamagePaladinImprovedDivineSmite.GuiPresentation.Title = "Feature/&PaladinImprovedDivineSmiteTitle";
            additionalDamagePaladinImprovedDivineSmite.GuiPresentation.Description = "Feature/&PaladinImprovedDivineSmiteDescription";

            AccessTools.Field(additionalDamagePaladinImprovedDivineSmite.GetType(), "damageAdvancement").SetValue(additionalDamagePaladinImprovedDivineSmite, RuleDefinitions.AdditionalDamageAdvancement.None);
            AccessTools.Field(additionalDamagePaladinImprovedDivineSmite.GetType(), "diceByRankTable").SetValue(additionalDamagePaladinImprovedDivineSmite, new List<DiceByRank>());
            AccessTools.Field(additionalDamagePaladinImprovedDivineSmite.GetType(), "familiesWithAdditionalDice").SetValue(additionalDamagePaladinImprovedDivineSmite, new List<String>());
            AccessTools.Field(additionalDamagePaladinImprovedDivineSmite.GetType(), "notificationTag").SetValue(additionalDamagePaladinImprovedDivineSmite, "ImprovedDivineSmite");
            AccessTools.Field(additionalDamagePaladinImprovedDivineSmite.GetType(), "triggerCondition").SetValue(additionalDamagePaladinImprovedDivineSmite, RuleDefinitions.AdditionalDamageTriggerCondition.AlwaysActive);
            
            DatabaseRepository.GetDatabase<FeatureDefinition>().Add(additionalDamagePaladinImprovedDivineSmite);
        }
    }
}