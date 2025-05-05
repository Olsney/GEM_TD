using UnityEngine;

namespace Game.View.Binder
{
    public interface IGameEntityViewBinder
    {
        void Bind(GameEntity entity, Vector3 at);
    }
}