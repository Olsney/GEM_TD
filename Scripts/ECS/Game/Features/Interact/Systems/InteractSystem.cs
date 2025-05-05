using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game.Interact
{
  public class InteractSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _interactables;
    private readonly IGroup<GameEntity> _inputs;
    private readonly IGroup<GameEntity> _raycasters;
    private readonly List<GameEntity> _buffer = new(128);

    public InteractSystem(GameContext game)
    {
      _interactables = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Interactable,
        //  GameMatcher.Hightlighted,
          GameMatcher.WorldPosition)
        .NoneOf(
          GameMatcher.Interacted));

      _inputs = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.UserInput,
          GameMatcher.InterractKey));

      _raycasters = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.InitialInteractDistance,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity interactable in _interactables.GetEntities(_buffer))
      foreach (GameEntity _ in _inputs)
      foreach (GameEntity raycaster in _raycasters)
      {
        float distance = Vector3.Distance(interactable.WorldPosition, raycaster.WorldPosition);

        if (distance > raycaster.InitialInteractDistance)
          return;

        interactable.isInteracted = true;
      }
    }
  }
}