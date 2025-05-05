using Entitas;

namespace Game
{
    public class RoundTimerResetAndStartSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _players;
        private readonly IGroup<GameEntity> _enemies;

        public RoundTimerResetAndStartSystem(GameContext game)
        {
            _players = game.GetGroup(GameMatcher.AllOf(GameMatcher.Player, GameMatcher.RoundTimer));
            _enemies = game.GetGroup(GameMatcher.AllOf(GameMatcher.Enemy, GameMatcher.Age));
        }

        public void Execute()
        {
            foreach (var player in _players)
            {
                // если уже начался отсчет времени, ничего не делаем
                if (player.RoundTimer > 0f)
                    continue;

                foreach (var enemy in _enemies)
                {
                    if (enemy.PlayerId != player.Id)
                        continue;

                    // нашли первого врага в раунде, сбрасываем таймер
                    player.ReplaceRoundTimer(0.01f); // ставим малое значение, чтобы больше не сбрасывалось
                    break;
                }
            }
        }
    }
}