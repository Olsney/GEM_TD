using UnityEngine;

namespace Game
{
  public interface IGameEntityView
  {
    // GameEntity Entity { get; }
    // void SetEntity(GameEntity entity);
     void ReleaseEntity();
    
    // ReSharper disable once InconsistentNaming
    GameObject gameObject { get; }
  }
}