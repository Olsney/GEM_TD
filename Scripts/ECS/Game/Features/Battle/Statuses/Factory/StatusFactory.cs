using System;
using Game.Entity;
using Game.Extensions;
using Services.Identifiers;

namespace Game.Battle
{
    public class StatusFactory : IStatusFactory
    {
        private readonly IIdentifierService _identifiers;

        public StatusFactory(IIdentifierService identifiers)
        {
            _identifiers = identifiers;
        }

        public GameEntity CreateStatus(StatusSetup setup, int producerId, int targetId)
        {
            GameEntity status;

            switch (setup.StatusEnum)
            {
                case StatusEnum.Poison:
                    status = CreatePoisonStatus(setup, producerId, targetId);
                    break;
                case StatusEnum.Freeze:
                    status = CreateFreezeStatus(setup, producerId, targetId);
                    break;
                case StatusEnum.DecreaseArmor:
            status = CreateDecreaseArmorStatus(setup, producerId, targetId);
            break;
        case StatusEnum.PoisonEnchant:
                    status = CreatePoisonEnchantStatus(setup, producerId, targetId);
                    break;
                case StatusEnum.ExplosiveEnchant:
                    status = CreateExplosiveEnchantStatus(setup, producerId, targetId);
                    break;

                default:
                    throw new Exception($"Status with type id {setup.StatusEnum} does not exist");
            }

            status
                .With(x => x.AddDuration(setup.Duration), when: setup.Duration > 0)
                .With(x => x.AddTimeLeft(setup.Duration), when: setup.Duration > 0)
                .With(x => x.AddPeriod(setup.Period), when: setup.Period > 0)
                .With(x => x.AddTimeSinceLastTick(0), when: setup.Period > 0)
                ;

            return status;
        }

        private GameEntity CreatePoisonStatus(StatusSetup setup, int producerId, int targetId)
        {
            return CreateGameEntity.Empty()
                    .AddId(_identifiers.Next())
                    .AddStatusTypeId(StatusEnum.Poison)
                    .AddEffectValue(setup.Value)
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                    .With(x => x.isStatus = true)
                    .With(x => x.isPoison = true)
                ;
        }

        private GameEntity CreateFreezeStatus(StatusSetup setup, int producerId, int targetId)
        {
            return CreateGameEntity.Empty()
                    .AddId(_identifiers.Next())
                    .AddStatusTypeId(StatusEnum.Freeze)
                    .AddEffectValue(setup.Value)
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                    .With(x => x.isStatus = true)
                    .With(x => x.isFreeze = true)
                ;
        }

        private GameEntity CreateDecreaseArmorStatus(StatusSetup setup, int producerId, int targetId)
    {
        return CreateGameEntity.Empty()
                .AddId(_identifiers.Next())
                .AddStatusTypeId(StatusEnum.DecreaseArmor)
                .AddEffectValue(setup.Value)
                .AddProducerId(producerId)
                .AddTargetId(targetId)
                .With(x => x.isStatus = true)
                .With(x => x.isDecreaseArmor = true)
            ;
    }

    private GameEntity CreatePoisonEnchantStatus(StatusSetup setup, int producerId, int targetId)
    {
      return CreateGameEntity.Empty()
          .AddId(_identifiers.Next())
          .AddStatusTypeId(StatusEnum.PoisonEnchant)
          .AddEnchantEnum(EnchantEnum.PoisonArmaments)
          .AddEffectValue(setup.Value)
          .AddProducerId(producerId)
          .AddTargetId(targetId)
          .With(x => x.isStatus = true)
          .With(x => x.isPoisonEnchant = true)
        ;      
    }

        private GameEntity CreateExplosiveEnchantStatus(StatusSetup setup, int producerId, int targetId)
        {
            return CreateGameEntity.Empty()
                    .AddId(_identifiers.Next())
                    .AddStatusTypeId(StatusEnum.ExplosiveEnchant)
                    .AddEnchantEnum(EnchantEnum.ExplosiveArmaments)
                    .AddEffectValue(setup.Value)
                    .AddProducerId(producerId)
                    .AddTargetId(targetId)
                    .With(x => x.isStatus = true)
                    .With(x => x.isExplosiveEnchant = true)
                ;
        }
    }
}