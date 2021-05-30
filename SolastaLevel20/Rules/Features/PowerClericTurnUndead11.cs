using HarmonyLib;

namespace SolastaLevel20.Rules.Features
{
    public static class PowerClericTurnUndead11
    {
        static FeatureDefinitionPower PowerClericTurnUndead8 => DatabaseRepository.GetDatabase<FeatureDefinitionPower>().TryGetElement("PowerClericTurnUndead8", "6fd2d50bba7337a43b4034a75d077911");

        public static void Load()
        {
            FeatureDefinitionPower powerClericTurnUndead11 = UnityEngine.Object.Instantiate(PowerClericTurnUndead8);
            AccessTools.Field(powerClericTurnUndead11.GetType(), "guid").SetValue(powerClericTurnUndead11, "14becbc17d194b7ea9231ee035c2f858");
            powerClericTurnUndead11.name = "PowerClericTurnUndead11";
            KillForm killForm = powerClericTurnUndead11.EffectDescription.EffectForms[0].KillForm;
            AccessTools.Field(killForm.GetType(), "challengeRating").SetValue(killForm, 2);
            DatabaseRepository.GetDatabase<FeatureDefinition>().Add(powerClericTurnUndead11);
        }
    }
}