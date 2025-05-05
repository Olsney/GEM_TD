using Entitas;
using Game.Towers;
using UnityEngine;

namespace Game.Battle
{
    public class ArmamentHitDetectionSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _armaments;
        private readonly GameContext _game;
        private readonly IArmamentFactory _armamentFactory;
        private const float HitDistance = 0.5f;

        public ArmamentHitDetectionSystem(GameContext game, IArmamentFactory armamentFactory)
        {
            _game = game;
            _armamentFactory = armamentFactory;
            _armaments = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Armament,
                    GameMatcher.WorldPosition,
                    GameMatcher.TargetId,
                    GameMatcher.TargetBuffer
                )
            );
        }

        public void Execute()
        {
            foreach (var armament in _armaments)
            {
                GameEntity target = armament.Target();
                GameEntity tower = armament.Producer();

                if (target == null)
                {
                    armament.isProcessed = true;
                    continue;
                }

                float distance = Vector3.Distance(armament.WorldPosition, target.WorldPosition);
                // armament.ReplaceDistanceToTarget(distance);

                if (distance <= HitDistance)
                {
                    if (tower.TowerEnum == TowerEnum.R1)
                    {
                        _armamentFactory
                            .CreateCleaveRequest(armament);
                    }

                    armament.isReadyToApplyEffect = true;
                    armament.TargetBuffer.Add(target.Id);
                }
            }
        }
    }
}