using HarmonyLib;

namespace SolastaLevel20.Rules.Features
{
    public static class AttributeModifierFighterIndomitable3
    {
        static FeatureDefinitionAttributeModifier AttributeModifierFighterIndomitable => DatabaseRepository.GetDatabase<FeatureDefinitionAttributeModifier>().TryGetElement("AttributeModifierFighterIndomitable", "");

        public static void Load()
        {
            FeatureDefinitionAttributeModifier attributeModifierFighterIndomitable3 = UnityEngine.Object.Instantiate(AttributeModifierFighterIndomitable);
            AccessTools.Field(attributeModifierFighterIndomitable3.GetType(), "guid").SetValue(attributeModifierFighterIndomitable3, "5c10d0830a84440d9bea436da7a9e75b");
            attributeModifierFighterIndomitable3.name = "attributeModifierFighterIndomitable3";
            attributeModifierFighterIndomitable3.GuiPresentation.Title = "Feature/&AttributeModifierFighterIndomitable3";

            AccessTools.Field(attributeModifierFighterIndomitable3.GetType(), "modifierValue").SetValue(attributeModifierFighterIndomitable3, 2);

            DatabaseRepository.GetDatabase<FeatureDefinition>().Add(attributeModifierFighterIndomitable3);
        }
    }
}