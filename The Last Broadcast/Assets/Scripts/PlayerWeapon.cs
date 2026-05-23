using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Weapon Particle Parent")]
    [SerializeField] private GameObject machineGuns;

    [Header("Crosshair")]
    [SerializeField] private RectTransform crosshair;
    [SerializeField] private Transform targetPoint;
    [SerializeField] private float targetDistance = 100f;

    private ParticleSystem[] machineGunParticles;
    private bool isFiring = false;

    private Camera mainCamera;

    private void Awake()
    {
        machineGunParticles = machineGuns.GetComponentsInChildren<ParticleSystem>(true);
        mainCamera = Camera.main;

        SetMachineGunEmission(false);
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimGuns();

    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    private void ProcessFiring()
    {
        SetMachineGunEmission(isFiring);
    }

    private void SetMachineGunEmission(bool enabled)
    {
        foreach (ParticleSystem particle in machineGunParticles)
        {
            var emissionModule = particle.emission;
            emissionModule.enabled = enabled;

            if (enabled && !particle.isPlaying)
            {
                particle.Play();
            }
        }
    }

    private void MoveCrosshair()
    {
        if (Mouse.current == null || crosshair == null)
        {
            return;
        }

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        crosshair.position = mousePosition;
    }

    private void MoveTargetPoint()
    {
        if (Mouse.current == null || targetPoint == null || mainCamera == null)
        {
            return;
        }

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Vector3 targetPointPosition = new Vector3(
            mousePosition.x,
            mousePosition.y,
            targetDistance
        );

        targetPoint.position = mainCamera.ScreenToWorldPoint(targetPointPosition);
    }

    private void AimGuns()
    {
        if (targetPoint == null)
        {
            return;
        }

        foreach (ParticleSystem particle in machineGunParticles)
        {
            Vector3 fireDirection = targetPoint.position - particle.transform.position;

            if (fireDirection == Vector3.zero)
            {
                continue;
            }

            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            particle.transform.rotation = rotationToTarget;
        }
    }
}