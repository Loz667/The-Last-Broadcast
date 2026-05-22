using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Weapon Particle Parent")]
    [SerializeField] private GameObject machineGuns;

    [Header("Crosshair")]
    [SerializeField] private RectTransform crosshair;

    private ParticleSystem[] machineGunParticles;
    private bool isFiring = false;

    private void Awake()
    {
        machineGunParticles = machineGuns.GetComponentsInChildren<ParticleSystem>(true);

        SetMachineGunEmission(false);
    }

    void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
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
}