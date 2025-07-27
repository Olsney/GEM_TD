namespace Game.Cameras
{
    public class CameraInputData
    {
        public float moveX;
        public float moveZ;
        public float rotate;
        public float zoom;
        
        public readonly string AxisHorizontal = "Horizontal";
        public readonly string AxisVertical = "Vertical";
        public readonly string AxisRotation = "Rotation";
        public readonly string AxisMouseX = "Mouse X";
        public readonly string AxisMouseY = "Mouse Y";
    }
}