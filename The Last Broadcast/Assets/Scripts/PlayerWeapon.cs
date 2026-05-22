using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Weapon Particle Parent")]
    [SerializeField] private GameObject machineGuns;

    private ParticleSystem[] machineGunParticles;

    private bool isFiring = false;

    private void Awake()
    {
        machineGunParticles = machineGuns.GetComponentsInChildren<ParticleSystem>(true);

        SetMachineGunEmission(false);
    }

    private void Update()
    {
        ProcessFiring();
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
}
