using Entitas;
using Services.ProjectData;
using Services.StaticData;
using UnityEngine;

namespace Game.Cameras
{
    public class DefineCameraBoundariesSystem : IInitializeSystem, IExecuteSystem
    {
        private readonly IGroup<GameEntity> _cameras;
        private readonly IStaticDataService _config;
        private readonly IProjectDataService _projectData;

        public DefineCameraBoundariesSystem(GameContext game, IStaticDataService config, IProjectDataService projectData)
        {
            _config = config;
            _projectData = projectData;

            _cameras = game.GetGroup(GameMatcher
                .AllOf(GameMatcher.Camera, GameMatcher.CameraBounds, GameMatcher.CameraTarget));
        }

        public void Initialize()
        {
            var mazeData = _projectData.CurrentMazeData;
            var halfWidth = mazeData.Width / 2f;
            var halfHeight = mazeData.Height / 2f;
            var offset = _config.ProjectConfig.CameraConfig.OffsetUp;

            foreach (var camera in _cameras)
            {
                var center = Vector3.zero; // или можно взять усредненные StartPositions

                var smth1 = center.x - halfWidth - offset;
                var smth2 = center.x + halfWidth + offset;
                var smth3 = center.z - halfHeight - offset;
                var smth4 = center.z + halfHeight + offset;

                var bounds = new CameraBoundsData();

                bounds.MinX = smth1;
                bounds.MaxX = smth2;
                bounds.MinZ = smth3;
                bounds.MaxZ = smth4;

                camera.ReplaceCameraBounds(bounds);
            }
        }

        public void Execute()
        {
            // логика ограничения позиции камеры — оставить без изменений
        }
    }
}