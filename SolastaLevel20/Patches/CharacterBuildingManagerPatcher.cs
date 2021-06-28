﻿using HarmonyLib;
using System.Collections.Generic;
using SolastaModApi;
using static SolastaLevel20.Models.MultiClass;
using System.Linq;

namespace SolastaLevel20.Patches
{
    class CharacterBuildingManagerPatcher
    {
        private static bool flip = false;

        [HarmonyPatch(typeof(CharacterBuildingManager), "GetLastAssignedClassAndLevel")]
        internal static class CharacterBuildingManager_GetLastAssignedClassAndLevel_Patch
        {
            internal static bool Prefix(CharacterBuildingManager __instance, out CharacterClassDefinition lastClassDefinition, out int level)
            {
                if (__instance.HeroCharacter.ClassesHistory.Count <= 0)
                {
                    lastClassDefinition = null;
                    level = 0;
                }
                else
                {
                    lastClassDefinition = __instance.HeroCharacter.ClassesHistory[__instance.HeroCharacter.ClassesHistory.Count - 1];
                    level = __instance.HeroCharacter.ClassesAndLevels[lastClassDefinition];
                    if (flip)
                    {
                        var heroName = __instance.HeroCharacter.Name + __instance.HeroCharacter.SurName;
                        lastClassDefinition = GetClassDefinition(NextHeroClass[heroName]);
                    }
                }
                return false;
            }
        }

        [HarmonyPatch(typeof(CharacterStageLevelGainsPanel), "EnterStage")]
        internal static class CharacterStageLevelGainsPanel_EnterStage_Patch
        {
            internal static void Prefix()
            {
                flip = true;
            }
            internal static void Postfix()
            {
                flip = false;
            }
        }

        [HarmonyPatch(typeof(CharacterBuildingManager), "GrantFeatures")]
        internal static class CharacterBuildingManager_GrantFeatures_Patch
        {
            internal static void Prefix(CharacterBuildingManager __instance, List<FeatureDefinition> grantedFeatures, string tag, bool clearPrevious = true, string optionalTagToCheck = null)
            {
                //If we are adding a level higher than level 1, exclude some features that would normally be added to a level 1 character
                if (__instance.HeroCharacter.ClassesHistory.Count > 1)
                {
                    grantedFeatures.RemoveAll(feature => FeaturesToExcludeFromMulticlassLevels.Contains(feature));
                    
                    //Also need to add logic to add extra skill points here
                }
            }

            private static readonly FeatureDefinition[] FeaturesToExcludeFromMulticlassLevels = new FeatureDefinition[]
            {
                DatabaseHelper.FeatureDefinitionPointPools.PointPoolClericSkillPoints,
                DatabaseHelper.FeatureDefinitionPointPools.PointPoolFighterSkillPoints,
                DatabaseHelper.FeatureDefinitionPointPools.PointPoolPaladinSkillPoints,
                DatabaseHelper.FeatureDefinitionPointPools.PointPoolRangerSkillPoints,
                DatabaseHelper.FeatureDefinitionPointPools.PointPoolRogueSkillPoints,
                DatabaseHelper.FeatureDefinitionPointPools.PointPoolWizardSkillPoints,
                DatabaseHelper.FeatureDefinitionProficiencys.ProficiencyClericSavingThrow,
                DatabaseHelper.FeatureDefinitionProficiencys.ProficiencyFighterSavingThrow,
                DatabaseHelper.FeatureDefinitionProficiencys.ProficiencyPaladinSavingThrow,
                DatabaseHelper.FeatureDefinitionProficiencys.ProficiencyRangerSavingThrow,
                DatabaseHelper.FeatureDefinitionProficiencys.ProficiencyRogueSavingThrow,
                DatabaseHelper.FeatureDefinitionProficiencys.ProficiencyWizardSavingThrow,
            };
        }
    }
}