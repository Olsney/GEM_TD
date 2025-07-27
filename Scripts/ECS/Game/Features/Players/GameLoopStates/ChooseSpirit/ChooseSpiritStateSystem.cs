using Entitas;
using Game.Battle.Factory;
using Services.StaticData;
using UnityEngine;

namespace Game.ChooseSpirit
{
    public class ChooseSpiritStateSystem : IExecuteSystem
    {
        // private readonly AbilityFactory _abilityFactory;
        private readonly IGroup<GameEntity> _spirits;
        private readonly IGroup<GameEntity> _players;
        private readonly IStaticDataService _config;

        public ChooseSpiritStateSystem(
            GameContext game,
            AbilityFactory abilityFactory,
            IStaticDataService config
        )
        {
            // _abilityFactory = abilityFactory;
            _config = config;

            _spirits = game.GetGroup(GameMatcher.TowerSpirit);

            _players = game.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Player,
                    GameMatcher.GameLoopStateEnum
                ));
        }

        public void Execute()
        {
            foreach (GameEntity player in _players)
            {
                if (player.gameLoopStateEnum.Value != GameLoopStateEnum.ChooseSpirit)
                    continue;

                if (player.hasTimer == false)
                    player.AddTimer(_config.ProjectConfig.ChooseSpiritTime);

                if (player.Timer > 0f)
                    return;
                
                Human(player);
                AiBot(player);

                player.RemoveTimer();
            }
        }

        private void Human(GameEntity player)
        {
            if (!player.isHuman)
                return;

            foreach (GameEntity spirit in _spirits)
            {
                if (spirit.PlayerId != player.Id)
                    continue;

                if (spirit.isChosen == false)
                    continue;

                player.ReplaceGameLoopStateEnum(GameLoopStateEnum.SpiritToTower);

                // _abilityFactory.CreateTowerBasicAttackAbility(1, spirit.Id);
                break;
            }
        }

        private void AiBot(GameEntity player)
        {
            if (player.isHuman)
                return;

            foreach (GameEntity spirit in _spirits)
            {
                if (spirit.PlayerId != player.Id)
                    continue;

                spirit.isChosen = true;

                player.ReplaceGameLoopStateEnum(GameLoopStateEnum.SpiritToTower);

                // _abilityFactory.CreateTowerBasicAttackAbility(1, spirit.Id);
                break;
            }
        }
    }
}