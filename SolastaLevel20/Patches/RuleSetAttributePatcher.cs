using HarmonyLib;

namespace SolastaLevel20.Patches
{
    class RuleSetAttributePatcher
    {
        [HarmonyPatch(typeof(RulesetAttribute), "MaxValue", MethodType.Setter)]
        internal static class RulesetAttribute_MaxValue_Setter_Patch
        {
            internal static void Postfix(ref int value, RulesetAttribute __instance)
            {
                if (__instance.Name == "CharacterLevel")
                    value = Main.MAX_LEVEL;
            }
        }

        [HarmonyPatch(typeof(RulesetAttribute), "MaxValue", MethodType.Getter)]
        internal static class RulesetAttribute_MaxValue_Getter_Patch
        {
            internal static bool Prefix(ref int __result, RulesetAttribute __instance)
            {
                if (__instance.Name == "CharacterLevel")
                {
                    __result = Main.MAX_LEVEL;
                    return false;
                }
                return true;
            }
        }
    }
}