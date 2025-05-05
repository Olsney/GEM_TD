using Entitas;
using Game.Extensions;
using UnityEngine;

namespace Game.Battle
{
    public class ApplyArmorFromStatsSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;

        public ApplyArmorFromStatsSystem(GameContext game)
        {
            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.BaseStats, 
                    GameMatcher.StatModifiers, 
                    GameMatcher.Armor)
            );
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            {
                statOwner.ReplaceArmor(Armor(statOwner).ZeroIfNegative());
                Debug.Log("Мы снизили армор в статах");
            }
        }

        private static float Armor(GameEntity statOwner)
        {
            return statOwner.BaseStats[StatEnum.Armor] + statOwner.StatModifiers[StatEnum.Armor];
        }
    }
}