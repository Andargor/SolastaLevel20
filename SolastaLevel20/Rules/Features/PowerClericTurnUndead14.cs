using HarmonyLib;

namespace SolastaLevel20.Rules.Features
{
    public static class PowerClericTurnUndead14
    {
        static FeatureDefinitionPower PowerClericTurnUndead8 => DatabaseRepository.GetDatabase<FeatureDefinitionPower>().TryGetElement("PowerClericTurnUndead8", "");

        public static void Load()
        {
            FeatureDefinitionPower powerClericTurnUndead11 = UnityEngine.Object.Instantiate(PowerClericTurnUndead8);
            AccessTools.Field(powerClericTurnUndead11.GetType(), "guid").SetValue(powerClericTurnUndead11, "1258a27f594542e1b9df6f9d36a50fbe");
            powerClericTurnUndead11.name = "PowerClericTurnUndead14";
            KillForm killForm = powerClericTurnUndead11.EffectDescription.EffectForms[0].KillForm;
            AccessTools.Field(killForm.GetType(), "challengeRating").SetValue(killForm, 3);
            DatabaseRepository.GetDatabase<FeatureDefinitionPower>().Add(powerClericTurnUndead11);
        }
    }
}