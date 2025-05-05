using System.Collections.Generic;
using Game.Cameras;
using Game.Enemies;
using Game.Towers;
using Tools.MazeDesigner;
using UnityEngine;

namespace Infrastructure.Projects
{
    [CreateAssetMenu(fileName = nameof(ProjectConfig), menuName = "Configs/" + nameof(ProjectConfig))]
    public class ProjectConfig : ScriptableObject
    {
        public float MaxThroneHealthPoint = 100f;
        public float EnemyDeathAnimationTime = 3f;
        public MazeDataSO BigMazeData;
        public MazeDataSO SmallMazeData;
        public int TowersPerRound = 5;
        public EnemyConfig EnemyConfig;
        public CameraConfig CameraConfig;

        public float SpiritPlacementTime = 0.1f;
        public float PlayerAbilityTime = 0.1f;
        public float ChooseSpiritTime = 0.2f;
        public int MaxPlayerLevel = 5;

        public int TotalCheckPoints = 6;
        public int EnemiesPerRound = 10;
        public float EnemySpawnCooldown = 1;

        public float DistanceToNextPoint = .2f;
        
        public float Epsilon = 0.001f; 

        public readonly Dictionary<int, List<int>> Chances = new()
        {
            {
                1, new List<int>
                    { 100, 0, 0, 0, 0 }
            },
            {
                2, new List<int>
                    { 80, 20, 0, 0, 0 }
            },
            {
                3, new List<int>
                    { 60, 30, 10, 0, 0 }
            },
            {
                4, new List<int>
                    { 40, 30, 20, 10, 0 }
            },
            {
                5, new List<int>
                    { 10, 30, 20, 20, 10 }
            }
        };

        public readonly Dictionary<TowerEnum, int> TowerLevels = new()
        {
            { TowerEnum.B1, 1 },
            { TowerEnum.B2, 2 },
            { TowerEnum.B3, 3 },
            { TowerEnum.B4, 4 },
            { TowerEnum.B5, 5 },

            { TowerEnum.D1, 1 },
            { TowerEnum.D2, 2 },
            { TowerEnum.D3, 3 },
            { TowerEnum.D4, 4 },
            { TowerEnum.D5, 5 },

            { TowerEnum.Y1, 1 },
            { TowerEnum.Y2, 2 },
            { TowerEnum.Y3, 3 },
            { TowerEnum.Y4, 4 },
            { TowerEnum.Y5, 5 },

            { TowerEnum.G1, 1 },
            { TowerEnum.G2, 2 },
            { TowerEnum.G3, 3 },
            { TowerEnum.G4, 4 },
            { TowerEnum.G5, 5 },

            { TowerEnum.E1, 1 },
            { TowerEnum.E2, 2 },
            { TowerEnum.E3, 3 },
            { TowerEnum.E4, 4 },
            { TowerEnum.E5, 5 },

            { TowerEnum.Q1, 1 },
            { TowerEnum.Q2, 2 },
            { TowerEnum.Q3, 3 },
            { TowerEnum.Q4, 4 },
            { TowerEnum.Q5, 5 },

            { TowerEnum.R1, 1 },
            { TowerEnum.R2, 2 },
            { TowerEnum.R3, 3 },
            { TowerEnum.R4, 4 },
            { TowerEnum.R5, 5 },

            { TowerEnum.P1, 1 },
            { TowerEnum.P2, 2 },
            { TowerEnum.P3, 3 },
            { TowerEnum.P4, 4 },
            { TowerEnum.P5, 5 }
        };

        public readonly Dictionary<int, List<TowerEnum>> Towers = new()
        {
            {
                1, new List<TowerEnum>
                {
                    TowerEnum.B1,
                    TowerEnum.D1,
                    TowerEnum.Y1,
                    TowerEnum.G1,
                    TowerEnum.E1,
                    TowerEnum.Q1,
                    TowerEnum.R1,
                    TowerEnum.P1
                }
            },
            {
                2, new List<TowerEnum>
                {
                    TowerEnum.B2,
                    TowerEnum.D2,
                    TowerEnum.Y2,
                    TowerEnum.G2,
                    TowerEnum.E2,
                    TowerEnum.Q2,
                    TowerEnum.R2,
                    TowerEnum.P2
                }
            },
            {
                3, new List<TowerEnum>
                {
                    TowerEnum.B3,
                    TowerEnum.D3,
                    TowerEnum.Y3,
                    TowerEnum.G3,
                    TowerEnum.E3,
                    TowerEnum.Q3,
                    TowerEnum.R3,
                    TowerEnum.P3
                }
            },
            {
                4, new List<TowerEnum>
                {
                    TowerEnum.B4,
                    TowerEnum.D4,
                    TowerEnum.Y4,
                    TowerEnum.G4,
                    TowerEnum.E4,
                    TowerEnum.Q4,
                    TowerEnum.R4,
                    TowerEnum.P4
                }
            },
            {
                5, new List<TowerEnum>
                {
                    TowerEnum.B5,
                    TowerEnum.D5,
                    TowerEnum.Y5,
                    TowerEnum.G5,
                    TowerEnum.E5,
                    TowerEnum.Q5,
                    TowerEnum.R5,
                    TowerEnum.P5
                }
            }
        };

        public float SpiritToTowerTime = 0.2f;
    }
}