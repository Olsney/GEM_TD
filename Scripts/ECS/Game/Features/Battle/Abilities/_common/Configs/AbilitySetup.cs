using System;
using System.Collections.Generic;
using Game.View;
using UnityEngine;

namespace Game.Battle.Configs
{
    [Serializable]
    public class AbilitySetup
    {
        public AbilityEnum AbilityEnum = AbilityEnum.SingleShotAttack;
        public Sprite Icon;
        public string Description = "ABOBA";

        public float Cooldown = 1;

        public GameEntityView ViewPrefab;
        public GameEntityView ExplosionPrefab;
        public GameEntityView MuzzleFlashPrefab;

        public List<EffectSetup> EffectSetups;
        public List<StatusSetup> StatusSetups;
    
        public ProjectileSetup ProjectileSetup;
        public AuraSetup AuraSetup;

        public int AdditionalTargetCount = 2;
    }
}