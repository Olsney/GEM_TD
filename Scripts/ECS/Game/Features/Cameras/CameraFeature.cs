using Services.SystemsFactoryServices;

namespace Game.Cameras
{
    // ReSharper disable once UnusedType.Global
    public sealed class CameraFeature : Feature
    {
        // ReSharper disable once UnusedParameter.Local
        public CameraFeature(ISystemFactory systems)
        {
            Add(systems.Create<FocusCameraOnPlayerSystem>());
            Add(systems.Create<InputCameraSystem>());
            Add(systems.Create<MoveCameraSystem>());
            Add(systems.Create<DragCameraSystem>());
            Add(systems.Create<StrafeCameraSystem>());
            Add(systems.Create<ResetCameraSystem>());
            Add(systems.Create<DefineCameraBoundariesSystem>());
            Add(systems.Create<ZoomCameraSystem>());
        }
    }
}