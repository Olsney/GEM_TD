using System.Collections.Generic;
using Game.GameMainFeature;
using Services.StaticData;
using Tools.MazeDesigner;
using UnityEngine;

namespace Services.ProjectData
{
    public class ProjectDataService : IProjectDataService
    {
        private readonly IStaticDataService _config;

        public ProjectDataService(IStaticDataService config)
        {
            _config = config;
        }

        public List<Vector2> StartPositions { get; } = new();
        public MazeDataSO CurrentMazeData { get; private set; }

        public void SetGameMode(GameModeEnum gameModeEnum)
        {
            int centerOffset = 1;
            int mazeLength;

            switch (gameModeEnum)
            {
                case GameModeEnum.SingleSmall:
                    CurrentMazeData = _config.ProjectConfig.SmallMazeData;

                    mazeLength = CurrentMazeData.Height;

                    StartPositions.Add(new Vector2(-mazeLength + 1 - centerOffset, centerOffset));

                    break;

                case GameModeEnum.RaceSmall:
                    CurrentMazeData = _config.ProjectConfig.SmallMazeData;
                    mazeLength = CurrentMazeData.Height;

                    StartPositions.Add(new Vector2(-mazeLength + 1 - centerOffset, centerOffset));
                    StartPositions.Add(new Vector2(centerOffset, centerOffset));
                    StartPositions.Add(new Vector2(-mazeLength + 1 - centerOffset, -mazeLength + 1 - centerOffset));
                    StartPositions.Add(new Vector2(centerOffset, -mazeLength + 1 - centerOffset));

                    break;

                case GameModeEnum.SingleLarge:
                    CurrentMazeData = _config.ProjectConfig.BigMazeData;

                    mazeLength = CurrentMazeData.Height;

                    StartPositions.Add(new Vector2(-mazeLength + 1 - centerOffset, centerOffset));

                    break;
            }
        }

        public void ResetGameModes()
        {
            StartPositions.Clear();
        }
    }
}