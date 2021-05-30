using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// ActionAffinityRogueCunningAction
using SolastaModApi;
using SolastaModApi.Extensions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionActionAffinitys;
using static SolastaModApi.DatabaseHelper.ActionDefinitions;

namespace SolastaLevel20.Rules.Features
{
    internal class ActionAffinityRangerVanishActionBuilder : BaseDefinitionBuilder<FeatureDefinitionActionAffinity>
    {
        const string ActionAffinityRangerVanishActionName = "AdditionalActionVanish";
        const string ActionAffinityRangerVanishActionGuid = "83711ec64d8c47bfa91053a00a1d0a83";

        protected ActionAffinityRangerVanishActionBuilder(string name, string guid) : base(ActionAffinityRogueCunningAction, name, guid)
        {
            Definition.GuiPresentation.Title = "Feature/&RangerVanishActionTitle";
            Definition.GuiPresentation.Description = "Feature/&RangerVanishActionDescription";

            Definition.AuthorizedActions.Clear();
            Definition.AuthorizedActions.Add(HideBonus.Id);
        }

        public static FeatureDefinitionActionAffinity CreateAndAddToDB(string name, string guid)
            => new ActionAffinityRangerVanishActionBuilder(name, guid).AddToDB();

        public static FeatureDefinitionActionAffinity ActionAffinityRangerVanishAction
            => CreateAndAddToDB(ActionAffinityRangerVanishActionName, ActionAffinityRangerVanishActionGuid);
    }
}
