using HarmonyLib;
using UnityEngine;

namespace SolastaLevel20.Patches
{
    class CharacterInformationPanelPatcher
    {
        [HarmonyPatch(typeof(CharacterInformationPanel), "EnumerateClassBadges")]
        internal static class CharacterInformationPanel_EnumerateClassBadges_Patch
        {
            internal static void Postfix(RectTransform ___classBadgesTable)
            {
                for (int index2 = 0; index2 < ___classBadgesTable.childCount; ++index2)
                {
                    Transform child = ___classBadgesTable.GetChild(index2);
                    child.gameObject.SetActive(true);
                }
            }
        }
    }


}