using System.Collections.Generic;
using Entitas;
using Game.Towers;
using Services.StaticData;
using UnityEngine;

namespace Game.Battle.SingleShotAttack.Systems
{
    public class SingleShotAttackAbilitySystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IGroup<GameEntity> _towers;
        private readonly IGroup<GameEntity> _abilities;
        private readonly List<GameEntity> _buffer = new(4);
        private readonly IStaticDataService _staticDataService;

        public SingleShotAttackAbilitySystem(
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
                    GameMatcher.SingleShotAbility,
                    GameMatcher.CooldownUp,
                    GameMatcher.ProducerId
                ));
        }

        public void Execute()
        {
            foreach (GameEntity ability in _abilities.GetEntities(_buffer))
            {
                GameEntity tower = _game.GetEntityWithId(ability.ProducerId);

                if (tower == null)
                    continue;

                if (!tower.hasTargetId)
                    continue;

                if (tower.isTowerSpirit)
                    continue;

                TowerConfig config = _staticDataService.GetTowerConfig(tower.TowerEnum);
                Vector3 at = tower.ShootingPointWorldPosition;
                
                _armamentFactory
                    .CreateTowerBasicAttackProjectile(at, config.BasicAttackSetup, tower.Rotation, tower.Id)
                    .AddProducerId(tower.Id)
                    .AddTargetId(tower.TargetId)
                    .AddDirection(default)
                    ;

                ability.PutOnCooldown(config.BasicAttackSetup.Cooldown);
            }
        }
    }
}