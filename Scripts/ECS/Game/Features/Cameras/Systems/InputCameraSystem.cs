using Entitas;
using UnityEngine;

namespace Game.Cameras
{
    public class InputCameraSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _cameras;

        public InputCameraSystem(GameContext game)
        {
            _cameras = game.GetGroup(GameMatcher
                .AllOf(
                    GameMatcher.CameraInput,
                    GameMatcher.CameraDrag
                ));
        }

        public void Execute()
        {
            foreach (GameEntity camera in _cameras)
            {
                camera.CameraInput.moveX = Input.GetAxis(camera.CameraInput.AxisHorizontal);
                camera.CameraInput.moveZ = Input.GetAxis(camera.CameraInput.AxisVertical);
                camera.CameraInput.rotate = Input.GetAxis(camera.CameraInput.AxisRotation);
                camera.CameraInput.zoom = Input.mouseScrollDelta.y;

                camera.ReplaceCameraInput(camera.CameraInput);

                if (Input.GetMouseButton(2)) //TODO: input service
                {
                    Vector3 mouseDelta = new Vector3(Input.GetAxis(camera.CameraInput.AxisMouseX), 0,
                        Input.GetAxis(camera.CameraInput.AxisMouseY));
                    camera.ReplaceCameraDrag(mouseDelta);
                }
            }
        }
    }
}