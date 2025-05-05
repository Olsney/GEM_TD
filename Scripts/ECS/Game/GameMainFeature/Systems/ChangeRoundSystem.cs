using Entitas;
using Services.StaticData;

namespace Game.GameMainFeature
{
    public class ChangeRoundSystem : IExecuteSystem
    {
        private readonly GameContext _gameContext;
        private readonly GameEntityFactories _factories;
        private readonly IStaticDataService _staticDataService;

        private readonly IGroup<GameEntity> _players;

        public ChangeRoundSystem(
            GameContext gameContext,
            GameEntityFactories factories,
            IStaticDataService staticDataService
        )
        {
            _gameContext = gameContext;
            _factories = factories;
            _staticDataService = staticDataService;

            _players = gameContext.GetGroup(
                GameMatcher.AllOf(
                    GameMatcher.Round,
                    GameMatcher.Player
                ));
        }

        public void Execute()
        {
            foreach (GameEntity player in _players)
            {
                GameEntity mainEntity = _gameContext.gameMainEntity;

                if (player.Round <= mainEntity.Round)
                    continue;

                // Обновляем текущий раунд в main entity
                mainEntity.ReplaceRound(player.Round);

                foreach (GameEntity player2 in _players)
                {
                    // Удаляем RoundTimer перед началом нового раунда
                    if (player2.hasRoundTimer)
                        player2.RemoveRoundTimer();

                    // Создаём RoundComplete сущность
                    int maxEnemies = _staticDataService.ProjectConfig.EnemiesPerRound;
                    _factories.CreateRoundComplete(player2.Id, mainEntity.Round, maxEnemies);
                }
            }
        }
    }
}