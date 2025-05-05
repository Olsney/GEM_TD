using Game.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Enemies
{
    [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configs/" + nameof(EnemyConfig))]
    public class EnemyConfig : ScriptableObject
    {
        public int Round;

        [SerializeField]
        public GameEntityView Prefab;

        [SerializeField]
        public float MoveSpeed;

        [SerializeField]
        public float RotationSpeed;

        [FormerlySerializedAs("MaxHP")]
        [SerializeField] public float MaxHealthPoints;
        [SerializeField] public float Armor;
    }
}