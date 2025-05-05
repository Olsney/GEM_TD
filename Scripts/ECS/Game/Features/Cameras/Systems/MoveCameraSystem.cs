using Entitas;
using Services.StaticData;
using Services.Times;
using UnityEngine;

namespace Game.Cameras
{
    public class MoveCameraSystem : IExecuteSystem
    {
        private readonly ITimeService _time;
        private readonly IStaticDataService _service;
        
        private readonly IGroup<GameEntity> _cameras;

        public MoveCameraSystem(GameContext game, ITimeService time, IStaticDataService service)
        {
            _time = time;
            _service = service;

            _cameras = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CameraTarget,
                    GameMatcher.CameraInput
                    ));
        }

        public void Execute()
        {
            var moveSpeed = _service.ProjectConfig.CameraConfig.MoveSpeed;

            foreach (GameEntity camera in _cameras)
            {
                Transform target = camera.CameraTarget;
                var input = camera.CameraInput;

                Vector3 moveDirection = new Vector3(input.moveX, 0, input.moveZ).normalized;
                target.Translate(moveDirection * moveSpeed * _time.DeltaTime, Space.World);
            }
        }
    }
}