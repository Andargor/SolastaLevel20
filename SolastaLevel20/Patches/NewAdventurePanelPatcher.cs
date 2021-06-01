using HarmonyLib;
using static SolastaModApi.Extensions.CampaignDefinitionExtensions;

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
                    campaignDefinition.SetMinLevel<CampaignDefinition>(1);
                    campaignDefinition.SetMaxLevel<CampaignDefinition>(Main.MOD_MAX_LEVEL);
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
                    userLocation.StartLevelMin = 1;
                    userLocation.StartLevelMax = Main.MOD_MAX_LEVEL;
                }
            }
        }
    }
}
