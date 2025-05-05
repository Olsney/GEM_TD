using System.Collections.Generic;
using Entitas;
using Game.Battle.SplitShot.Data;
using Game.Towers;
using Services.StaticData;
using UnityEngine;

namespace Game.Battle.SplitShot.Systems
{
    public class SplitshotAbilitySystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IStaticDataService _staticDataService;

        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _towers;

        private readonly List<GameEntity> _buffer = new List<GameEntity>(64);

        public SplitshotAbilitySystem(
            GameContext game,
            IArmamentFactory armamentFactory,
            IStaticDataService staticDataService
        )
        {
            _game = game;
            _armamentFactory = armamentFactory;
            _staticDataService = staticDataService;

            _abilities = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.SplitshotAbility,
                    GameMatcher.CooldownUp,
                    GameMatcher.ProducerId,
                    GameMatcher.SplitshotTargets
                ));

            _towers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TowerEnum,
                    GameMatcher.WorldPosition,
                    GameMatcher.AttackRange
                ));
        }

        public void Execute()
        {
            foreach (GameEntity tower in _towers)
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                if (ability.ProducerId != tower.Id)
                    continue;

                List<int> targets = new List<int>();

                // AbilityEnum abilityEnum = tower.Abilities[0].AbilityEnum;
                //TODO тут мы храним лист абилок и первая это базовая. Поэтому такая херня

                if (!tower.hasTargetId)
                    continue;

                if (tower.isTowerSpirit)
                    continue;

                TowerConfig config = _staticDataService.GetTowerConfig(tower.TowerEnum);

                _armamentFactory
                    .CreateSplitshot(tower.WorldPosition, config.BasicAttackSetup, tower.Rotation, tower.Id)
                    .AddProducerId(tower.Id)
                    .AddTargetId(tower.TargetId)
                    .AddDirection(default)
                    ;

                targets.Add(tower.TargetId);

                foreach (TargetDistanceData? targetData in ability.SplitshotTargets)
                {
                    if (targetData == null)
                        continue;

                    _armamentFactory
                        .CreateSplitshot(tower.WorldPosition, config.BasicAttackSetup, tower.Rotation, tower.Id)
                        .AddProducerId(tower.Id)
                        .AddTargetId(targetData.Value.TargetId)
                        .AddDirection(default)
                        ;

                    targets.Add(targetData.Value.TargetId);
                }

                ability.PutOnCooldown(ability.Cooldown);

                bool isAllDifferent = true;

                for (var i = 0; i < targets.Count - 1; i++)
                {
                    for (var j = i + 1; j < targets.Count; j++)
                    {
                        if (targets[i] == targets[j])
                        {
                            isAllDifferent = false;
                            break;
                        }
                    }
                }

                if (!isAllDifferent)
                {
                    Debug.LogError("Цели повторяются");
                }
            }
        }
    }
}