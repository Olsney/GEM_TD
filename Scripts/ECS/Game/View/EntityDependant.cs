using UnityEngine;
using UnityEngine.Serialization;

namespace Game.View
{
    public abstract class EntityDependant : MonoBehaviour
    {
        [FormerlySerializedAs("GameGameEntityBinder")]
        [FormerlySerializedAs("GameEntityBinder")]
        [FormerlySerializedAs("EntityBinder")]
        [FormerlySerializedAs("EntityView")]
        public GameEntityView GameEntityView;

        protected GameEntity Entity => GameEntityView != null
            ? GameEntityView.Entity
            : null;

        private void Awake()
        {
            if (!GameEntityView)
                GameEntityView = GetComponent<GameEntityView>();
        }
    }
}