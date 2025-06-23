using Entitas;
using Game.Battle;
using Game.Extensions;
using Services.StaticData;
using UnityEngine;

namespace Game.PlayerAbility.HealThroneAbility.Systems
{
    public class HealThroneAbilitySystem : IExecuteSystem
    {
        private readonly IStaticDataService _staticDataService;

        private readonly IGroup<GameEntity> _healRequests;
        private readonly IGroup<GameEntity> _humans;
        private readonly IGroup<GameEntity> _healThroneAbilities;

        public HealThroneAbilitySystem(GameContext game, IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
            _healRequests = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.HealThroneRequest));

            _healThroneAbilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.PlayerHealThroneAbility,
                    GameMatcher.Cooldown,
                    GameMatcher.EffectSetups));

            _humans = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Human,
                    GameMatcher.Player,
                    GameMatcher.Id,
                    GameMatcher.CurrentHealthPoints
                    ));
        }

        public void Execute()
        {
            foreach (GameEntity human in _humans)
            foreach (GameEntity healAbility in _healThroneAbilities)
            foreach (GameEntity dummy in _healRequests)
            {
                foreach (EffectSetup effectSetup in healAbility.EffectSetups)
                {
                    float resultHealthPoint = human.CurrentHealthPoints + effectSetup.Value;

                    if (resultHealthPoint <= _staticDataService.ProjectConfig.MaxPlayerHealth)
                    {
                        human.ReplaceCurrentHealthPoints(resultHealthPoint);
                        human.LoseGold(_staticDataService.GetPlayerAbilitySetup(AbilityEnum.HealThrone).Cost);
                    }
                }

                healAbility.PutOnCooldown();
            }
        }
    }
}