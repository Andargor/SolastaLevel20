using SolastaModApi;
using SolastaModApi.Extensions;
using static SolastaModApi.DatabaseHelper.FeatureDefinitionPowers;

namespace SolastaLevel20.Rules.Features
{
    internal class PowerClericTurnUndeadBuilder : BaseDefinitionBuilder<FeatureDefinitionPower>
    {
        const string PowerClericTurnUndead11Name = "PowerClericTurnUndead11";
        const string PowerClericTurnUndead11Guid = "14becbc17d194b7ea9231ee035c2f858";
        const string PowerClericTurnUndead14Name = "PowerClericTurnUndead14";
        const string PowerClericTurnUndead14Guid = "1258a27f594542e1b9df6f9d36a50fbe";
        const string PowerClericTurnUndead17Name = "PowerClericTurnUndead17";
        const string PowerClericTurnUndead17Guid = "b0ef65ba1e784628b1c5b4af75d4f395";

        protected PowerClericTurnUndeadBuilder(string name, string guid, int challengeRating) : base(PowerClericTurnUndead8, name, guid)
        {
            Definition.EffectDescription.EffectForms[0].KillForm.SetChallengeRating(challengeRating);
        }

        public static FeatureDefinitionPower CreateAndAddToDB(string name, string guid, int challengeRating)
            => new PowerClericTurnUndeadBuilder(name, guid, challengeRating).AddToDB();

        public static FeatureDefinitionPower PowerClericTurnUndead11 =>
            CreateAndAddToDB(PowerClericTurnUndead11Name, PowerClericTurnUndead11Guid, 2);

        public static FeatureDefinitionPower PowerClericTurnUndead14 =>
            CreateAndAddToDB(PowerClericTurnUndead14Name, PowerClericTurnUndead14Guid, 3);

        public static FeatureDefinitionPower PowerClericTurnUndead17 =>
            CreateAndAddToDB(PowerClericTurnUndead17Name, PowerClericTurnUndead17Guid, 4);
    }
}