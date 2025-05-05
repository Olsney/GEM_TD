using System.Collections.Generic;
using Game.GameMainFeature;
using Tools.MazeDesigner;
using UnityEngine;

namespace Services.ProjectData
{
    public interface IProjectDataService
    {
        List<Vector2> StartPositions { get; }
        MazeDataSO CurrentMazeData { get; }
        void SetGameMode(GameModeEnum gameModeEnum);
        void ResetGameModes();
    }
}