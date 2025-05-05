using System;
using Game.Battle;

namespace Game.Extensions
{
    public static class AbilityExtentions
    {
        public static GameEntity AddAbilityComponent(this GameEntity entity, AbilityEnum abilityEnum)
        {
            switch (abilityEnum)
            {
                case AbilityEnum.Unknown:
                    break;
                case AbilityEnum.SingleShotAttack:
                    entity.isSingleShotAbility = true;
                    break;
                case AbilityEnum.SplitShotAttack:
                    entity.isSplitshotAbility = true;
                    break;
                case AbilityEnum.Cleave:
                    entity.isCleaveAbility = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(abilityEnum), abilityEnum, null);
            }

            return entity;
        }
    }
}