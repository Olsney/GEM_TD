using System.Collections.Generic;
using Game.View;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Battle
{
    [CreateAssetMenu(fileName = nameof(EnchantConfig), menuName = "Configs/" + nameof(EnchantConfig))]
    public class EnchantConfig : ScriptableObject
    {
        [FormerlySerializedAs("TypeId")]
        public EnchantEnum Enum;

        public Sprite Icon;

        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;

        public float Radius;
        public GameEntityView ViewPrefab;
    }
}