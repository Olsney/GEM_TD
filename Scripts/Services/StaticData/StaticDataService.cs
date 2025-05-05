using System;
using System.Collections.Generic;
using System.Linq;
using Game.Enemies;
using Game.Towers;
using Infrastructure.Projects;
using Services.AssetProviders;
using UnityEngine;

namespace Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private readonly IAssetProvider _assetProvider;

        private Dictionary<TowerEnum, TowerConfig> _towers = new();
        private Dictionary<int, EnemyConfig> _enemyConfigs = new();

        public StaticDataService(
            IAssetProvider assetProvider
        )
        {
            _assetProvider = assetProvider;
        }

        public ProjectConfig ProjectConfig { get; private set; }

        public void LoadAll()
        {
            ProjectConfig = _assetProvider.LoadScriptable<ProjectConfig>(nameof(ProjectConfig));

            _enemyConfigs = Resources
                .LoadAll<EnemyConfig>("Enemies")
                .ToDictionary(x => x.Round, x => x);

            LoadTowers();
        }

        public EnemyConfig GetEnemyConfig(int round)
        {
            return !_enemyConfigs.TryGetValue(round, out EnemyConfig config)
                ? _enemyConfigs.Last().Value
                : config;
        }

        public TowerConfig GetTowerConfig(TowerEnum towerEnum)
        {
            if (_towers.TryGetValue(towerEnum, out TowerConfig config))
                return config;

            throw new Exception($"Tower config for {towerEnum} was not found");
        }

        private void LoadTowers()
        {
            _towers = Resources
                .LoadAll<TowerConfig>("Towers")
                .ToDictionary(x => x.TowerEnum, x => x);
        }
    }
}