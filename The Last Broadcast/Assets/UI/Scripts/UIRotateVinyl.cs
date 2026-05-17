using UnityEngine;

public class UIRotateVinyl : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 20f;

    private void Start()
    {
        LeanTween.rotateAround(
            gameObject,
            Vector3.forward,
            -360f,
            rotationSpeed
        )
        .setLoopClamp()
        .setEase(LeanTweenType.linear);
    }

    private void OnDisable()
    {
        LeanTween.cancel(gameObject);
    }
}
