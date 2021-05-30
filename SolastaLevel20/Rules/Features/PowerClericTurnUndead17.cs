using HarmonyLib;

namespace SolastaLevel20.Rules.Features
{
    public static class PowerClericTurnUndead17
    {
        static FeatureDefinitionPower PowerClericTurnUndead8 => DatabaseRepository.GetDatabase<FeatureDefinitionPower>().TryGetElement("PowerClericTurnUndead8", "");

        public static void Load()
        {
            FeatureDefinitionPower powerClericTurnUndead11 = UnityEngine.Object.Instantiate(PowerClericTurnUndead8);
            AccessTools.Field(powerClericTurnUndead11.GetType(), "guid").SetValue(powerClericTurnUndead11, "b0ef65ba1e784628b1c5b4af75d4f395");
            powerClericTurnUndead11.name = "PowerClericTurnUndead17";
            KillForm killForm = powerClericTurnUndead11.EffectDescription.EffectForms[0].KillForm;
            AccessTools.Field(killForm.GetType(), "challengeRating").SetValue(killForm, 4);
            DatabaseRepository.GetDatabase<FeatureDefinitionPower>().Add(powerClericTurnUndead11);
        }
    }
}