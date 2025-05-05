using System.Collections.Generic;
using Entitas;
using Game.Battle.Configs;
using Game.Towers;
using Services.StaticData;

namespace Game.Battle.CleaveAbility.Systems
{
    public class CleaveAbilitySystem : IExecuteSystem
    {
        private readonly GameContext _game;
        private readonly IArmamentFactory _armamentFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IGroup<GameEntity> _abilities;
        private readonly IGroup<GameEntity> _armaments;
        private List<GameEntity> _buffer = new List<GameEntity>(8);

        public CleaveAbilitySystem(GameContext game, IArmamentFactory armamentFactory,
            IStaticDataService staticDataService)
        {
            _game = game;
            _armamentFactory = armamentFactory;
            _staticDataService = staticDataService;
            
            _abilities = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.CleaveAbility));

            _armaments = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.ReadyToCleave,
                    GameMatcher.WorldPosition));
        }

        public void Execute()
        {
            foreach (GameEntity armament in _armaments.GetEntities(_buffer))
            {
                GameEntity tower = _game.GetEntityWithId(armament.ProducerId);

                if (tower == null)
                    continue;

                TowerConfig config = _staticDataService.GetTowerConfig(tower.TowerEnum);

                foreach (AbilitySetup abilitySetup in config.Abilities)
                {
                    if (abilitySetup.AbilityEnum == AbilityEnum.Cleave)
                    {
                        _armamentFactory
                            .CreateCleave(armament.WorldPosition, abilitySetup)
                            ;
                    }

                    armament.isReadyToCleave = false;
                    armament.isProcessed = false;
                }
            }
        }
    }
}