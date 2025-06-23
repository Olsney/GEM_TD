using System.Collections.Generic;
using UnityEngine;

namespace Game.Towers.Views
{
    public class TowerLevelListenerView : EntityDependant, ILevelListener
    {
        private readonly Dictionary<int, float> _levels = new()
        {
            { 1, .65f },
            { 2, .70f },
            { 3, .75f },
            { 4, .85f },
            { 5, .90f },
            { 6, 1 },
        };

        private void Start()
        {
            if (Entity == null)
                return;

            Entity.AddLevelListener(this);
            OnLevel(Entity, Entity.Level);
        }

        public void OnLevel(GameEntity entity, int value)
        {
            transform.localScale = Vector3.one * _levels[value]; 
        }
    }
}