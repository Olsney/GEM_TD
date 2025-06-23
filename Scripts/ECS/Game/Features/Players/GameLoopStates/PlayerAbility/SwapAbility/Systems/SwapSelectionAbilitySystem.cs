using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game.PlayerAbility.SwapAbility.Systems
{
    public class SwapSelectionAbilitySystem : IExecuteSystem
    {
        private readonly GameContext _game;

        private readonly IGroup<GameEntity> _swapAbilities;
        private readonly IGroup<GameEntity> _clicks;
        private readonly IGroup<GameEntity> _highlighted;
        private readonly IGroup<GameEntity> _players;

        public SwapSelectionAbilitySystem(GameContext game)
        {
            _game = game;

            _swapAbilities = _game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.SwapSelectionActive,
                    GameMatcher.SwapRequest,
                    GameMatcher.PlayerId
                ));

            _clicks = _game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.LeftMouseButtonClick
                ));

            _highlighted = _game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Highlighted,
                    GameMatcher.Id
                ));

            _players = _game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.Id
                ));
        }

        public void Execute()
        {
            if (_highlighted.count > 1)
                throw new InvalidOperationException("Боже иди нахуй");

            foreach (GameEntity player in _players)
            foreach (var swap in _swapAbilities)
            {
                if (swap.hasSwapFirstTowerSelected)
                {
                    var entity = _game.GetEntityWithId(swap.swapFirstTowerSelected.Value);

                    if (player.Id != entity.PlayerId)
                    {
                        entity.isSelected = true;
                    }
                }

                if (swap.hasSwapSecondTowerSelected)
                {
                    var entity = _game.GetEntityWithId(swap.swapSecondTowerSelected.Value);

                    if (player.Id == entity.PlayerId)
                    {
                        entity.isSelected = true;
                    }
                }
            }

            
            foreach (var swap in _swapAbilities)
            foreach (var click in _clicks)
            foreach (var highlight in _highlighted)
            {
                if (!swap.hasSwapFirstTowerSelected)
                {
                    swap.ReplaceSwapFirstTowerSelected(highlight.Id);
                }
                else
                {
                    swap.ReplaceSwapSecondTowerSelected(highlight.Id);
                }
            }
        }
    }
}