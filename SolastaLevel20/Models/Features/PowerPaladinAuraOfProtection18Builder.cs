using SolastaModApi;
using SolastaModApi.Extensions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionPowers;

namespace SolastaLevel20.Models.Features
{
    internal sealed class PowerPaladinAuraOfProtection18Builder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        private static FeatureDefinitionPower _instance;

        const string PowerPaladinAuraOfProtection18Name = "Level20_PowerPaladinAuraOfProtection18";
        const string PowerPaladinAuraOfProtection18Guid = "1574c379dfb74cfeb3488209bd3b6d33";

        public PowerPaladinAuraOfProtection18Builder() : base(PowerPaladinAuraOfProtection, PowerPaladinAuraOfProtection18Name, PowerPaladinAuraOfProtection18Guid)
        {
            var ed = Definition.EffectDescription;

            // Set to 7 instead of 6 because of range bug.  Change back to 6 if TA fix.
            ed.SetTargetParameter(7);
            ed.SetRangeParameter(0);
            ed.SetRequiresTargetProximity(false);

            Definition.SetOverriddenPower(PowerPaladinAuraOfProtection);

            // TODO: localize
            Definition.GuiPresentation.Description = "You and your allies within 30ft cannot be frightened.";
            Definition.GuiPresentation.Title = "Improved Aura of Protection";
        }

        public static FeatureDefinitionPower Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PowerPaladinAuraOfProtection18Builder().AddToDB();
                }

                return _instance;
            }
        }
    }
}