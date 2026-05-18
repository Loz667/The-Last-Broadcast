using UnityEngine;

public class AudioStartFromTime : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float startTime = 43f;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();

        }

        if (audioSource == null)
        {
            Debug.LogWarning("No AudioSource found on this GameObject.");
            return;
        }

        if (audioSource.clip == null)
        {
            Debug.LogWarning("No AudioClip assigned to the AudioSource.");
            return;
        }

        
        audioSource.time = Mathf.Clamp(startTime, 0f, audioSource.clip.length);

        audioSource.Play();
    }
}
