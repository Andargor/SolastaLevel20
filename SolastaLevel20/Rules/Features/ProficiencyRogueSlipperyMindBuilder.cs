using SolastaModApi;
using SolastaModApi.Extensions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionProficiencys;

namespace SolastaLevel20.Rules.Features
{
    internal class ProficiencyRogueSlipperyMindBuilder : BaseDefinitionBuilder<FeatureDefinitionProficiency>
    {
        const string ProficiencyRogueSlipperyMindName = "ProficiencyRogueSlipperyMind";
        const string ProficiencyRogueSlipperyMindGuid = "b7eb00f96e13495ea4af1389fafca546";

        protected ProficiencyRogueSlipperyMindBuilder(string name, string guid) : base(ProficiencyRogueSavingThrow, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&ProficiencyRogueSlipperyMindTitle";
            Definition.GuiPresentation.Description = "Feature/&ProficiencyRogueSlipperyMindDescription";
            Definition.Proficiencies.Add("Wisdom");
        }

        private static FeatureDefinitionProficiency CreateAndAddToDB(string name, string guid)
            => new ProficiencyRogueSlipperyMindBuilder(name, guid).AddToDB();

        public static readonly FeatureDefinitionProficiency ProficiencyRogueSlipperyMind
            = CreateAndAddToDB(ProficiencyRogueSlipperyMindName, ProficiencyRogueSlipperyMindGuid);
    }
}