using System.Collections.Generic;
using Game.Battle.Configs;
using Game.Entity;
using Game.Extensions;
using Services.Identifiers;
using Services.StaticData;
using UnityEngine;

namespace Game.Battle
{
    public class ArmamentFactory : IArmamentFactory
    {
        private const int TargetBufferSize = 16;

        private readonly IIdentifierService _identifiers;
        private readonly IStaticDataService _staticDataService;
        private readonly GameEntityFactories _factories;

        public ArmamentFactory(
            IIdentifierService identifiers,
            IStaticDataService staticDataService,
            GameEntityFactories factories
        )
        {
            _identifiers = identifiers;
            _staticDataService = staticDataService;
            _factories = factories;
        }

        public GameEntity CreateTowerBasicAttackProjectile(
            Vector3 at,
            AbilitySetup abilitySetup,
            Quaternion rotation,
            int towerId
        )
        {
            GameEntity armament = CreateGameEntity
                    .Empty()
                    .AddId(_identifiers.Next())
                    .AddPrefab(abilitySetup.ViewPrefab)
                    .AddWorldPosition(at)
                    .AddEffectSetups(abilitySetup.EffectSetups)
                    .AddStatusSetups(abilitySetup.StatusSetups)
                    .AddMoveSpeed(abilitySetup.ProjectileSetup.Speed)
                    .AddRadius(abilitySetup.ProjectileSetup.ContactRadius)
                    .AddTargetBuffer(new List<int>(TargetBufferSize))
                    .AddProcessedTargets(new List<int>(TargetBufferSize))
                    .AddLayerMask(CollisionLayerEnum.Enemy.AsMask())
                    .With(x => x.isArmament = true)
                    .With(x => x.AddTargetLimit(1))
                    .With(x => x.isMovementAvailable = true)
                    .With(x => x.isReadyToCollectTargets = true)
                    .With(x => x.isCollectingTargetsContinuously = true)
                ;

            _factories.CreateMuzzleFlashEffect(at, rotation, towerId);

            return armament;
        }

        public GameEntity CreateSplitshot(
            Vector3 at,
            AbilitySetup abilitySetup,
            Quaternion rotation,
            int towerId
        )
        {
            GameEntity gameEntity = CreateGameEntity
                .Empty()
                .AddId(_identifiers.Next())
                .AddPrefab(abilitySetup.ViewPrefab)
                .AddWorldPosition(at)
                .AddEffectSetups(abilitySetup.EffectSetups)
                .AddStatusSetups(abilitySetup.StatusSetups)
                .AddMoveSpeed(abilitySetup.ProjectileSetup.Speed)
                .AddRadius(abilitySetup.ProjectileSetup.ContactRadius)
                .AddTargetBuffer(new List<int>(TargetBufferSize))
                .AddProcessedTargets(new List<int>(TargetBufferSize))
                .AddLayerMask(CollisionLayerEnum.Enemy.AsMask())
                .AddSelfDestructTimer(3)
                .With(x => x.isArmament = true)
                .With(x => x.AddTargetLimit(1))
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isReadyToCollectTargets = true)
                .With(x => x.isCollectingTargetsContinuously = true)
                ;
            
            _factories.CreateMuzzleFlashEffect(at, rotation, towerId);
            
            return gameEntity;
        }

        public GameEntity CreateCleaveRequest(GameEntity armament)
        {
            return CreateGameEntity
                .Empty()
                .AddWorldPosition(armament.WorldPosition)
                .AddProducerId(armament.ProducerId)
                .With(x => x.isReadyToCleave = true);
        }

        public GameEntity CreateCleave(
            Vector3 at, 
            AbilitySetup abilitySetup
            )
        {
            return CreateGameEntity
                .Empty()
                .AddId(_identifiers.Next())
                .AddWorldPosition(at)
                .AddEffectSetups(abilitySetup.EffectSetups)
                .AddMoveSpeed(abilitySetup.ProjectileSetup.Speed)
                .AddRadius(abilitySetup.ProjectileSetup.ContactRadius)
                .AddTargetBuffer(new List<int>(TargetBufferSize))
                .AddProcessedTargets(new List<int>(TargetBufferSize))
                .AddLayerMask(CollisionLayerEnum.Enemy.AsMask())
                .AddSelfDestructTimer(3f)
                .AddCleaveArmamentRadius(3f)
                .With(x => x.isArmament = true)
                .With(x => x.isMovementAvailable = true)
                .With(x => x.isReadyToCollectTargets = true)
                .With(x => x.isCollectingTargetsContinuously = true) 
                .With(x => x.isCleaveArmament = true)
                ;
        }
    }
}