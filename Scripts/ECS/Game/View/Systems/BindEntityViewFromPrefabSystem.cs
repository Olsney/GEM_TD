using System.Collections.Generic;
using Entitas;
using Game.View.Binder;
using UnityEngine;

namespace Game.View.Systems
{
    public class BindEntityViewFromPrefabSystem : IExecuteSystem
    {
        private readonly IGameEntityViewBinder _binder;

        private readonly IGroup<GameEntity> _entities;
        private readonly List<GameEntity> _buffer = new(32);

        public BindEntityViewFromPrefabSystem(
            GameContext game,
            IGameEntityViewBinder gameEntityViewBinder
        )
        {
            _binder = gameEntityViewBinder;

            _entities =
                game.GetGroup(
                    GameMatcher
                        .AllOf(
                            GameMatcher.Prefab
                        )
                        .NoneOf(
                            GameMatcher.View
                        )
                );
        }

        public void Execute()
        {
            foreach (GameEntity entity in _entities.GetEntities(_buffer))
            {
                Vector3 at = new Vector3(1000, 1000, 1000);

                if (entity.hasWorldPosition)
                    at = entity.WorldPosition;

                _binder.Bind(entity, at);
                entity.RemovePrefab();
            }
        }
    }
}