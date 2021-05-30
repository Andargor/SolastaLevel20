using SolastaModApi;
using SolastaModApi.Extensions;
using System;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionAttributeModifiers;

namespace SolastaLevel20.Rules.Features
{
    internal class AttributeModifierFighterIndomitableBuilder : BaseDefinitionBuilder<FeatureDefinitionAttributeModifier>
    {
        const string AttributeModifierFighterIndomitable2Name = "AttributeModifierFighterIndomitable2";
        const string AttributeModifierFighterIndomitable2Guid = "8a2f09cafd7b47d886cb0ce098c4f477";

        const string AttributeModifierFighterIndomitable3Name = "AttributeModifierFighterIndomitable3";
        const string AttributeModifierFighterIndomitable3Guid = "5c10d0830a84440d9bea436da7a9e75b";

        protected AttributeModifierFighterIndomitableBuilder(string name, string guid, int modifierValue) : base(AttributeModifierFighterIndomitable, name, guid)
        {
            Definition.SetModifierValue(modifierValue);
        }

        public static FeatureDefinitionAttributeModifier CreateAndAddToDB(string name, string guid, int modifierValue)
            => new AttributeModifierFighterIndomitableBuilder(name, guid, modifierValue).AddToDB();

        public static Lazy<FeatureDefinitionAttributeModifier> AttributeModifierFighterIndomitable2 => new Lazy<FeatureDefinitionAttributeModifier>(
            CreateAndAddToDB(AttributeModifierFighterIndomitable2Name, AttributeModifierFighterIndomitable2Guid, 2));

        public static Lazy<FeatureDefinitionAttributeModifier> AttributeModifierFighterIndomitable3 => new Lazy<FeatureDefinitionAttributeModifier>(
            CreateAndAddToDB(AttributeModifierFighterIndomitable3Name, AttributeModifierFighterIndomitable3Guid, 3));
    }
}