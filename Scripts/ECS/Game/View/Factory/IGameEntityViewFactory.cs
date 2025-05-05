using UnityEngine;

namespace Game.View.Factory
{
    public interface IGameEntityViewFactory
    {
        void Create(GameEntity entity, Vector3 at);
    }
}