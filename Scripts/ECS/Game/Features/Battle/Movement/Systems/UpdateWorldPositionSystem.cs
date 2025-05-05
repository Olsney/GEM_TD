using Entitas;
using Services.Times;
using UnityEngine;

namespace Game.Battle
{
    public class UpdateWorldPositionSystem : IExecuteSystem
    {
        private readonly ITimeService _timeService;
        private readonly IGroup<GameEntity> _group;

        public UpdateWorldPositionSystem(GameContext game, ITimeService timeService)
        {
            _timeService = timeService;
            _group = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.WorldPosition,
                    GameMatcher.Direction,
                    GameMatcher.MoveSpeed,
                    GameMatcher.MovementAvailable
                )
            );
        }

        public void Execute()
        {
            foreach (GameEntity entity in _group)
            {
                Vector3 position = entity.WorldPosition +
                                   entity.Direction * (entity.MoveSpeed * _timeService.DeltaTime);
                entity.ReplaceWorldPosition(position);
            }
        }
    }
}