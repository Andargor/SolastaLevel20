using SolastaModApi;
using SolastaModApi.Extensions;
using System;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionAdditionalDamages;

namespace SolastaLevel20.Rules.Features
{
    internal class AdditionalDamagePaladinImprovedDivineSmiteBuilder : BaseDefinitionBuilder<FeatureDefinitionAdditionalDamage>
    {
        const string AdditionalDamagePaladinImprovedDivineSmiteName = "AdditionalDamagePaladinImprovedDivineSmite";
        const string AdditionalDamagePaladinImprovedDivineSmiteGuid = "d7dbc91bbe4842648787691097f6b2a1";

        protected AdditionalDamagePaladinImprovedDivineSmiteBuilder(string name, string guid) : base(AdditionalDamagePaladinDivineSmite, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&PaladinImprovedDivineSmiteTitle";
            Definition.GuiPresentation.Description = "Feature/&PaladinImprovedDivineSmiteDescription";

            Definition.SetDamageAdvancement(RuleDefinitions.AdditionalDamageAdvancement.None);
            Definition.SetNotificationTag("ImprovedDivineSmite");
            Definition.SetTriggerCondition(RuleDefinitions.AdditionalDamageTriggerCondition.AlwaysActive);

            // not required initialized in FeatureDefinitionAdditionalDamage
            // Definition.SetField("diceByRankTable", new List<DiceByRank>());
            // Definition.SetField("familiesWithAdditionalDice", new List<string>());

        }

        public static FeatureDefinitionAdditionalDamage CreateAndAddToDB(string name, string guid)
            => new AdditionalDamagePaladinImprovedDivineSmiteBuilder(name, guid).AddToDB();

        public static Lazy<FeatureDefinitionAdditionalDamage> AdditionalDamagePaladinImprovedDivineSmite
            => new Lazy<FeatureDefinitionAdditionalDamage>(CreateAndAddToDB(AdditionalDamagePaladinImprovedDivineSmiteName, AdditionalDamagePaladinImprovedDivineSmiteGuid));
    }
}