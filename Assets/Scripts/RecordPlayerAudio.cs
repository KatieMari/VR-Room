using UnityEngine;

public class RecordPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private Vinyl currentVinyl;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Vinyl"))
        {
            Vinyl vinyl = other.GetComponent<Vinyl>();
            if (vinyl != null && vinyl.song != null)
            {
                audioSource.clip = vinyl.song;
                audioSource.Play();
                currentVinyl = vinyl;
                Debug.Log("Now playing: " + vinyl.song.name);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Vinyl"))
        {
            Vinyl vinyl = other.GetComponent<Vinyl>();
            if (vinyl != null && vinyl == currentVinyl)
            {
                audioSource.Stop();
                currentVinyl = null;
                Debug.Log("Vinyl removed. Stopped playing.");
            }
        }
    }
}
