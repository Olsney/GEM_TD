﻿using Entitas;
using Game.EntityIndices;

namespace Game.Battle
{
    public class StatChangeSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _statOwners;
        private readonly GameContext _game;

        public StatChangeSystem(GameContext game)
        {
            _game = game;

            _statOwners = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id,
                    GameMatcher.BaseStats,
                    GameMatcher.StatModifiers));
        }

        public void Execute()
        {
            foreach (GameEntity statOwner in _statOwners)
            foreach (StatEnum stat in statOwner.BaseStats.Keys)
            {
                statOwner.StatModifiers[stat] = 0;

                foreach (GameEntity statChange in _game.TargetStatChanges(stat, statOwner.Id))
                    statOwner.StatModifiers[stat] += statChange.EffectValue;
            }
        }
    }
}