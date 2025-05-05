using Entitas;
using Game.Battle.SplitShot.Data;
using UnityEngine;

namespace Game.Battle.SplitShot.Systems
{
    public class SplitshotTargetsSelectionSystem : IExecuteSystem
    {
        private readonly GameContext _game;

        private readonly IGroup<GameEntity> _towers;
        private readonly IGroup<GameEntity> _enemies;
        private readonly IGroup<GameEntity> _abilities;
        
        public SplitshotTargetsSelectionSystem(GameContext game)
        {
            _game = game;

            _towers = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.TowerEnum,
                    GameMatcher.WorldPosition,
                    GameMatcher.PlayerId,
                    GameMatcher.AttackRange
                ));

            _abilities = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SplitshotAbility,
                    GameMatcher.SplitshotTargets,
                    GameMatcher.PlayerId
                ));

            _enemies = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Enemy,
                    GameMatcher.WorldPosition,
                    GameMatcher.PlayerId
                ));
        }

        public void Execute()
        {
            foreach (GameEntity tower in _towers)
            foreach (GameEntity ability in _abilities)
            {
                if (ability.ProducerId != tower.Id) 
                    continue;
                
                if (tower.PlayerId != ability.PlayerId) 
                    continue;

                for (int i = 0; i < ability.SplitshotTargets.Length; i++)
                    ability.SplitshotTargets[i] = null;

                foreach (GameEntity enemy in _enemies)
                {
                    if (enemy.PlayerId != tower.PlayerId) 
                        continue;

                    float dist = Vector3.Distance(tower.WorldPosition, enemy.WorldPosition);
                   
                    if (dist > tower.AttackRange) 
                        continue;
                    
                    if (!tower.hasTargetId)
                        continue;

                    if (enemy.Id == tower.TargetId) 
                        continue;

                    bool alreadySelected = false;

                    for (int j = 0; j < ability.SplitshotTargets.Length; j++)
                    {
                        TargetDistanceData? t = ability.SplitshotTargets[j];

                        if (t != null && t.Value.TargetId == enemy.Id)
                        {
                            alreadySelected = true;
                            break;
                        }
                    }

                    if (alreadySelected)
                        continue;

                    int freeIndex = -1;

                    for (int j = 0; j < ability.SplitshotTargets.Length; j++)
                    {
                        if (ability.SplitshotTargets[j] == null)
                        {
                            freeIndex = j;
                            break;
                        }
                    }

                    if (freeIndex != -1)
                    {
                        ability.SplitshotTargets[freeIndex] = new TargetDistanceData
                        {
                            TargetId = enemy.Id,
                            Distance = dist
                        };
                        continue;
                    }

                    int farIndex = 0;
                    float farDistance = ability.SplitshotTargets[0]!.Value.Distance;

                    for (int j = 1; j < ability.SplitshotTargets.Length; j++)
                    {
                        float d = ability.SplitshotTargets[j]!.Value.Distance;

                        if (d > farDistance)
                        {
                            farDistance = d;
                            farIndex = j;
                        }
                    }

                    if (dist < farDistance)
                    {
                        ability.SplitshotTargets[farIndex] = new TargetDistanceData
                        {
                            TargetId = enemy.Id,
                            Distance = dist
                        };
                    }
                }
            }
        }
    }
}