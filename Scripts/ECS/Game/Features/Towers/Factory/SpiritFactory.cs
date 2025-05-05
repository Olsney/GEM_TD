using System.Collections.Generic;
using Game.Battle;
using Game.Battle.Configs;
using Game.Battle.Factory;
using Game.Entity;
using Game.Extensions;
using Game.View;
using Services.AssetProviders;
using Services.Identifiers;
using Services.StaticData;
using UnityEngine;

namespace Game.Towers
{
    public class SpiritFactory
    {
        private readonly IIdentifierService _identifiers;
        private readonly IAssetProvider _assets;
        private readonly AbilityFactory _abilityFactory;
        private readonly IStaticDataService _staticDataService;

        public SpiritFactory(
            IIdentifierService identifiers,
            IAssetProvider assets,
            AbilityFactory abilityFactory,
            IStaticDataService staticDataService
        )
        {
            _identifiers = identifiers;
            _assets = assets;
            _abilityFactory = abilityFactory;
            _staticDataService = staticDataService;
        }

        public GameEntity CreateSpirit(
            int worldPosX,
            int worldPosZ,
            int mazePosX,
            int mazePosY,
            TowerEnum towerEnum,
            int gameLoopWave,
            int playerId
        )
        {
            Dictionary<StatEnum, float> baseStats = InitStats.EmptyStatDictionary()
                .With(x => x[StatEnum.AttackCooldown] = 0.5f)
                .With(x => x[StatEnum.AttackRange] = 5f)
                .With(x => x[StatEnum.AttackTimer] = 4f);

            int id = _identifiers.Next();

            TowerConfig config = _staticDataService.GetTowerConfig(towerEnum);
            GameEntity basicAttackAbility = _abilityFactory.CreateAbility(id, config.BasicAttackSetup, playerId);

            List<AbilitySetup> abilitySetups = config.Abilities;

            GameEntity spirit = CreateGameEntity
                    .Empty()
                    .AddId(id)
                    .AddPrefab(_assets.LoadAsset(towerEnum.ToString()).GetComponent<GameEntityView>())
                    .AddStatModifiers(InitStats.EmptyStatDictionary())
                    .AddBaseStats(baseStats)
                    .AddWorldPosition(new Vector3(worldPosX, 0, worldPosZ))
                    .AddMazePosition(new Vector2Int(mazePosX, mazePosY))
                    .AddTowerEnum(towerEnum)
                    .AddRound(gameLoopWave)
                    .AddAttackCooldown(baseStats[StatEnum.AttackCooldown])
                    .AddAttackRange(baseStats[StatEnum.AttackRange])
                    .AddAttackTimer(baseStats[StatEnum.AttackTimer])
                    .AddRotation(Quaternion.Euler(Vector3.zero))
                    .AddPlayerId(playerId)
                    .AddBasicAbilityId(basicAttackAbility.Id)
                    .AddAbilities(new List<GameEntity>())
                    .AddAbilityComponent(config.BasicAttackSetup.AbilityEnum)
                    .With(x => x.isCanRaycast = true)
                    .With(x => x.isTowerSpirit = true)
                ;

            foreach (AbilitySetup abilitySetup in abilitySetups)
            {
                spirit.AddAbilityComponent(abilitySetup.AbilityEnum);
                spirit.Abilities.Add(_abilityFactory.CreateAbility(id, abilitySetup, playerId));
            }

            return spirit;
        }
    }
}