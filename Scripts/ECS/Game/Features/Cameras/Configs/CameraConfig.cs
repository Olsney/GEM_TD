using UnityEngine;

namespace Game.Cameras
{
    [CreateAssetMenu(menuName = "Configs/Camera", fileName = nameof(CameraConfig))]
    public class CameraConfig : ScriptableObject
    {
        [field: Header("Movement Speed")]
        [Range(0f, 20f)]
        [field: SerializeField]
        public float MoveSpeed { get; private set; } = 20f;

        [field: Header("Zoom Speed")]
        [Range(0f, 20f)]
        [field: SerializeField]
        public float ZoomSpeed { get; private set; } = 10f;

        [field: Header("Minimum approach distance")]
        [Range(-10f, 5f)]
        [field: SerializeField]
        public float MinHeight { get; private set; } = -5f;

        [field: Header("Maximum distance of separation")]
        [Range(0f, 10f)]
        [field: SerializeField]
        public float MaxHeight { get; private set; } = 5f;

        [field: Header("The speed of the camera movement through touching the edge of the screen with the mouse")]
        [Range(0f, 20f)]
        [field: SerializeField]
        public float StrafeSpeed { get; private set; } = 15f;

        [field: Header("Screen edge thickness before camera movement")]
        [Range(0f, 20f)]
        [field: SerializeField]
        public float EdgeThickness { get; private set; } = 20f;

        [field: Header("Отступ от границы death зоны камеры сверху")]
        [Range(0f, 5f)]
        [field: SerializeField]
        public float OffsetUp { get; private set; } = 2f;

        [field: Header("Отступ от границы death зоны камеры снизу")]
        [Range(2f, 7f)]
        [field: SerializeField]
        public float OffsetDown { get; private set; } = 4f;
    }
}