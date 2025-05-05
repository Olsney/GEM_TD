using Game.Enemies;
using Game.Towers;
using Infrastructure.Projects;

namespace Services.StaticData
{
    public interface IStaticDataService
    {
        ProjectConfig ProjectConfig { get; }

        void LoadAll();
        TowerConfig GetTowerConfig(TowerEnum towerEnum);

        EnemyConfig GetEnemyConfig(int round);
    }
}