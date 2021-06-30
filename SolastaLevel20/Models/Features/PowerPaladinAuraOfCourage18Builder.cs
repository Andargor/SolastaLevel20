using SolastaModApi;
using SolastaModApi.Extensions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionPowers;

namespace SolastaLevel20.Models.Features
{
    internal sealed class PowerPaladinAuraOfCourage18Builder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        private static FeatureDefinitionPower _instance;

        const string PowerPaladinAuraOfCourage18Name = "Level20_PowerPaladinAuraOfCourage18";
        const string PowerPaladinAuraOfCourage18Guid = "d68c46024ea8432b981506a13ae35ecd";

        public PowerPaladinAuraOfCourage18Builder() : base(PowerPaladinAuraOfCourage, PowerPaladinAuraOfCourage18Name, PowerPaladinAuraOfCourage18Guid)
        {
            var ed = Definition.EffectDescription;

            // Set to 7 instead of 6 because of range bug.  Change back to 6 if TA fix.
            ed.SetTargetParameter(7);
            ed.SetRangeParameter(0);
            ed.SetRequiresTargetProximity(false);

            Definition.SetOverriddenPower(PowerPaladinAuraOfCourage);

            // TODO: localize
            Definition.GuiPresentation.Description = "Grant a saving throw bonus to allies withing 30ft.";
            Definition.GuiPresentation.Title = "Improved Aura of Courage";
        }

        public static FeatureDefinitionPower Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PowerPaladinAuraOfCourage18Builder().AddToDB();
                }

                return _instance;
            }
        }
    }

}