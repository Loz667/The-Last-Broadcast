using UnityEngine;

public class PropellerRotate : MonoBehaviour
{
    [Header("Propeller Speed Settings")]
    [SerializeField] private float startSpeed = 50f;
    [SerializeField] private float maxSpeed = 1500f;
    [SerializeField] private float accelerationTime = 5f;

    [Header("Rotation Axis")]
    [SerializeField] private bool rotateClockwise = true;

    private float currentSpeed;
    private float accelerationTimer;

    private void Start()
    {
        currentSpeed = startSpeed;
        accelerationTimer = 0f;
    }

    private void Update()
    {
        // Gradually increase the speed from startSpeed to maxSpeed
        if (accelerationTimer < accelerationTime)
        {
            accelerationTimer += Time.deltaTime;

            float t = accelerationTimer / accelerationTime;
            currentSpeed = Mathf.Lerp(startSpeed, maxSpeed, t);
        }
        else
        {
            currentSpeed = maxSpeed;
        }

        // Choose rotation direction
        float direction = rotateClockwise ? -1f : 1f;

        // Rotate the propeller on its local Z-axis
        transform.Rotate(
            0f,
            0f,
            direction * currentSpeed * Time.deltaTime,
            Space.Self
        );
    }
}