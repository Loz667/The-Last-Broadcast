using UnityEngine;

public class UIScale : MonoBehaviour
{
    [Header("Pulse Settings")]
    [SerializeField] private float pulseScale = 1.15f;
    [SerializeField] private float pulseSpeed = 3f;

    [Header("Time Settings")]
    [SerializeField] private bool ignoreTimeScale = true;

    private Vector3 originalScale;

    private void Awake()
    {
        originalScale = transform.localScale;
    }

    private void OnEnable()
    {
        transform.localScale = originalScale;
    }

    private void Update()
    {
        float time = ignoreTimeScale ? Time.unscaledTime : Time.time;

        // Creates a smooth value between 0 and 1
        float pulse = (Mathf.Sin(time * pulseSpeed) + 1f) / 2f;

        // Creates the target scale between original size and enlarged size
        Vector3 targetScale = Vector3.Lerp(
            originalScale,
            originalScale * pulseScale,
            pulse
        );

        transform.localScale = targetScale;
    }

    private void OnDisable()
    {
        transform.localScale = originalScale;
    }
}