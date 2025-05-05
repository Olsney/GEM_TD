using Game.View.Registrars;
using UnityEngine;

namespace Game.Towers
{
    public class ShootingPointWorldPositionRegistrar : EntityComponentRegistrar, IWorldPositionListener
    {
        public Transform Transform;
        
        private void Start()
        {
            Entity.AddWorldPositionListener(this);
            OnWorldPosition(Entity, Entity.WorldPosition);
        }

        public override void RegisterComponents()
        {
            Entity.AddShootingPointWorldPosition(Transform.position);
        }

        public override void UnregisterComponents()
        {
            Entity.RemoveShootingPointWorldPosition();
        }

        public void OnWorldPosition(GameEntity entity, Vector3 value)
        {
            Entity.ReplaceShootingPointWorldPosition(Transform.position);
        }
    }
}