using System.Collections.Generic;
using Entitas;

namespace Game.Enemies
{
    public class CountKilledEnemiesSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _roundCompletes;
        private readonly IGroup<GameEntity> _frags;
        private readonly List<GameEntity> _buffer = new List<GameEntity>(1);

        public CountKilledEnemiesSystem(GameContext game)
        {
            _frags = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.Round,
                        GameMatcher.PlayerId,
                        GameMatcher.EnemyFrag
                    )
            );
            
            _roundCompletes = game.GetGroup(
                GameMatcher
                    .AllOf(
                        GameMatcher.RoundComplete,
                        GameMatcher.PlayerId,
                        GameMatcher.Round,
                        GameMatcher.EnemiesKilled
                    )
            );
        }

        public void Execute()
        {
            foreach (GameEntity frag in _frags.GetEntities(_buffer))
            foreach (GameEntity roundComplete in _roundCompletes)
            {
                if (frag.PlayerId != roundComplete.PlayerId)
                    continue;
                
                if (frag.Round != roundComplete.Round)
                    continue;

                roundComplete.ReplaceEnemiesKilled(roundComplete.EnemiesKilled + 1);
                
                frag.isDestructed = true;
                frag.isEnemyFrag = false;
            }
        }
    }
}