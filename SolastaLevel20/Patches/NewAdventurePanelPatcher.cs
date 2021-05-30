using HarmonyLib;

namespace SolastaLevel20.Patches
{
    class NewAdventurePanelPatcher
    {
        [HarmonyPatch(typeof(NewAdventurePanel), "SelectCampaign")]
        internal static class NewAdventurePanel_SelectedCampaign_Patch
        {
            internal static void Prefix(CampaignDefinition campaignDefinition)
            {
                if (campaignDefinition != null)
                {
                    AccessTools.Field(campaignDefinition.GetType(), "minLevel").SetValue(campaignDefinition, 1);
                    AccessTools.Field(campaignDefinition.GetType(), "maxLevel").SetValue(campaignDefinition, Main.MAX_LEVEL);
                }
            }
        }

        [HarmonyPatch(typeof(NewAdventurePanel), "SelectUserLocation")]
        internal static class NewAdventurePanel_SelectUserLocation_Patch
        {
            internal static void Prefix(UserLocation userLocation)
            {
                if (userLocation != null)
                {
                    AccessTools.Field(userLocation.GetType(), "startLevelMin").SetValue(userLocation, 1);
                    AccessTools.Field(userLocation.GetType(), "startLevelMax").SetValue(userLocation, Main.MAX_LEVEL);
                }
            }
        }
    }
}
