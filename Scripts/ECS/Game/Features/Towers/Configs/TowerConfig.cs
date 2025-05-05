using System.Collections.Generic;
using Game.Battle.Configs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Towers
{
    [CreateAssetMenu(fileName = nameof(TowerConfig), menuName = "Configs/" + nameof(TowerConfig))]
    public class TowerConfig : SerializedScriptableObject
    {
        public TowerEnum TowerEnum;
        public TowerEnum[] Recipe;
        public TowerEnum DowngradeTo;
        public Color Color;

        // [OdinSerialize]
        // public Dictionary<AbilityEnum, AbilityConfig> Abilities = new();

        [field: SerializeField]
        public AbilitySetup BasicAttackSetup { get; protected set; }

        public List<AbilitySetup> Abilities;
    }
}