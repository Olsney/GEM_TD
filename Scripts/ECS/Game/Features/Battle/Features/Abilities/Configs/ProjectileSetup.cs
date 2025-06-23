using System;
using UnityEngine.Serialization;

namespace Game.Battle.Configs
{
  [Serializable]
  public class ProjectileSetup
  {
    public int ProjectileCount = 1;
    
    [FormerlySerializedAs("AttackSpeed")]
    [FormerlySerializedAs("Speed")]
    public float MoveSpeed;
    public int Pierce = 1;
    public float ContactRadius;
    public float Lifetime;
    
    public float OrbitRadius;
  }
}