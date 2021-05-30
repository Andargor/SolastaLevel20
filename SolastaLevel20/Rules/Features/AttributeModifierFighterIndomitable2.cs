using HarmonyLib;

namespace SolastaLevel20.Rules.Features
{
    public static class AttributeModifierFighterIndomitable2
    {
        static FeatureDefinitionAttributeModifier AttributeModifierFighterIndomitable => DatabaseRepository.GetDatabase<FeatureDefinitionAttributeModifier>().TryGetElement("AttributeModifierFighterIndomitable", "");

        public static void Load()
        {
            FeatureDefinitionAttributeModifier attributeModifierFighterIndomitable2 = UnityEngine.Object.Instantiate(AttributeModifierFighterIndomitable);
            AccessTools.Field(attributeModifierFighterIndomitable2.GetType(), "guid").SetValue(attributeModifierFighterIndomitable2, "8a2f09cafd7b47d886cb0ce098c4f477");
            attributeModifierFighterIndomitable2.name = "AttributeModifierFighterIndomitable2";
            attributeModifierFighterIndomitable2.GuiPresentation.Title = "Feature/&AttributeModifierFighterIndomitable2";
            AccessTools.Field(attributeModifierFighterIndomitable2.GetType(), "modifierValue").SetValue(attributeModifierFighterIndomitable2, 2);

            DatabaseRepository.GetDatabase<FeatureDefinition>().Add(attributeModifierFighterIndomitable2);
        }
    }
}