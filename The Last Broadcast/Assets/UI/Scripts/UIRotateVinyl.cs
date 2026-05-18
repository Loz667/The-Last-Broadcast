using UnityEngine;

public class UIRotateVinyl : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private bool rotateClockwise = true;

    [Header("Time Settings")]
    [SerializeField] private bool ignoreTimeScale = true;

    private void Update()
    {
        float direction = rotateClockwise ? -1f : 1f;
        float deltaTime = ignoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime;

        transform.Rotate(
            0f,
            0f,
            direction * rotationSpeed * deltaTime,
            Space.Self
        );
    }
}