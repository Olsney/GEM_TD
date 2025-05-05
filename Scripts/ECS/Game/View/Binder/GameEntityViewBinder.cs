using Game.View.Factory;
using UnityEngine;

namespace Game.View.Binder
{
    public class GameEntityViewBinder : IGameEntityViewBinder
    {
        private readonly IGameEntityViewFactory _factory;

        public GameEntityViewBinder(
            IGameEntityViewFactory factory
        )
        {
            _factory = factory;
        }

        public void Bind(GameEntity entity, Vector3 at)
        {
            _factory.Create(entity, at);
        }
    }
}