using Entitas;
using Services.StaticData;
using Services.Times;
using UnityEngine;

namespace Game.Cameras
{
    public class ZoomCameraSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _cameras;

        private readonly ITimeService _time;
        private readonly IStaticDataService _service;

        public ZoomCameraSystem(GameContext game, ITimeService time, IStaticDataService service)
        {
            _time = time;
            _service = service;

            _cameras = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CameraTarget,
                    GameMatcher.CameraInput
                )
            );
        }

        public void Execute()
        {
            var zoomSpeed = _service.ProjectConfig.CameraConfig.ZoomSpeed;
            var minHeight = _service.ProjectConfig.CameraConfig.MinHeight;
            var maxHeight = _service.ProjectConfig.CameraConfig.MaxHeight;

            foreach (GameEntity camera in _cameras)
            {
                var target = camera.CameraTarget;
                var input = camera.CameraInput;

                Vector3 position = target.position;
                float targetYposition = position.y - input.zoom * zoomSpeed * _time.DeltaTime;

                position.y = Mathf.Clamp(targetYposition, minHeight, maxHeight);

                target.position = position;
            }
        }
    }
}