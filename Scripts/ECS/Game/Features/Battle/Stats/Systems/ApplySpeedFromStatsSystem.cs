using Entitas;
using Game.Extensions;

namespace Game.Battle
{
    public class ApplySpeedFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplySpeedFromStatsSystem(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BaseStats,
                    GameMatcher.StatModifiers,
                    GameMatcher.MoveSpeed));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            {
                statOwner.ReplaceMoveSpeed(MoveSpeed(statOwner).ZeroIfNegative());
            }
        }

        private static float MoveSpeed(GameEntity statOwner)
        {
            return statOwner.BaseStats[StatEnum.MoveSpeed] + statOwner.StatModifiers[StatEnum.MoveSpeed];
        }
    }
}