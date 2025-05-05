using Game.Battle.Configs;
using Game.Battle.SplitShot.Data;
using Game.Entity;
using Game.Extensions;
using Services.Identifiers;

namespace Game.Battle.Factory
{
    public class AbilityFactory
    {
        private readonly IIdentifierService _identifiers;

        public AbilityFactory(
            IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateAbility(int towerId, AbilitySetup setup, int playerId)
        {
            GameEntity ability = CreateGameEntity.Empty()
                .AddId(_identifiers.Next())
                .AddAbilityEnum(setup.AbilityEnum)
                .AddCooldown(setup.Cooldown)
                .AddProducerId(towerId)
                .AddPlayerId(playerId)
                .PutOnCooldown();

            ability.AddAbilityComponent(setup.AbilityEnum);

            if (setup.AbilityEnum == AbilityEnum.SplitShotAttack)
                ability.AddSplitshotTargets(new TargetDistanceData?[2]);
            
            return ability;
        }
    }
}