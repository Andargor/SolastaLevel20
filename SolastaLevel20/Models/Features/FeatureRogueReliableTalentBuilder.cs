using SolastaModApi;
using SolastaModApi.Extensions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionDieRollModifiers;

namespace SolastaLevel20.Models.Features
{
    /// <summary>
    /// This class does nothing.  Used for UI and for detection by RulesetCharacterVerifyAbilityCheckPatcher
    /// </summary>
    internal class FeatureRogueReliableTalentBuilder : BaseDefinitionBuilder<FeatureDefinitionDieRollModifier>
    {
        const string FeatureRogueReliableTalentName = "FeatureRogueReliableTalent";
        const string FeatureRogueReliableTalentGuid = "9864606fa1bd4c108fd9272fd0780768";

        protected FeatureRogueReliableTalentBuilder(string name, string guid) : base(DieRollModifierHalfingLucky, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&FeatureRogueReliableTalentTitle"; 
            Definition.GuiPresentation.Description = "Feature/&FeatureRogueReliableTalentDescription";
            Definition.GuiPresentation.SetHidden(false);

            Definition.SetMinRollValue(1);
            Definition.SetRerollCount(0);
            Definition.SetMaxRollValue(20);
        }

        private static FeatureDefinitionDieRollModifier CreateAndAddToDB(string name, string guid)
            => new FeatureRogueReliableTalentBuilder(name, guid).AddToDB();

        public static readonly FeatureDefinitionDieRollModifier FeatureRogueReliableTalent
            = CreateAndAddToDB(FeatureRogueReliableTalentName, FeatureRogueReliableTalentGuid);
    }
}