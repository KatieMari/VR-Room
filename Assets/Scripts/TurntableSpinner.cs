using UnityEngine;

public class TurntableSpinner : MonoBehaviour
{
    public float spinSpeed = 100f;
    public AudioSource audioSource;

    private void Update()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            // Rotate around the Y-axis (upward)
            transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
        }
    }
}
