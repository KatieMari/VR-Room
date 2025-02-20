using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecordPlayerController : MonoBehaviour
{
    public AudioSource recordAudioSource;  // Reference to the AudioSource attached to the record player
    public GameObject vinyl;  // Reference to the vinyl object
    public GameObject needle;  // Reference to the needle
    public Transform vinylSlot;  // Slot where the vinyl will snap
    public float vinylRotationSpeed = 10f;  // Speed at which the vinyl rotates
    public float needleMoveSpeed = 2f;  // Speed at which the needle moves onto the vinyl

    private bool isVinylPlaying = false;
    private Vector3 needleOriginalPosition;  // The starting position of the needle

    void Start()
    {
        // Save the original position of the needle (before it moves)
        needleOriginalPosition = needle.transform.position;

        // Ensure no music is playing at the start
        if (recordAudioSource != null)
        {
            recordAudioSource.Stop();
        }
    }

    void Update()
    {
        if (isVinylPlaying)
        {
            // Rotate the vinyl while the music is playing
            vinyl.transform.Rotate(Vector3.up, vinylRotationSpeed * Time.deltaTime);

            // Move the needle only along the Y-axis (keeping X and Z fixed)
            Vector3 targetPosition = new Vector3(needleOriginalPosition.x, vinylSlot.position.y, needleOriginalPosition.z);
            needle.transform.position = Vector3.MoveTowards(needle.transform.position, targetPosition, needleMoveSpeed * Time.deltaTime);
        }
    }

    // Called when a vinyl is placed in the socket
  public void OnVinylPlaced(Vinyl placedVinyl)
{
    // Log to verify if the AudioSource has an AudioClip assigned
    if (recordAudioSource.clip == null)
    {
        Debug.LogWarning("AudioSource does not have an AudioClip assigned!");
    }
    else
    {
        Debug.Log("AudioSource has an AudioClip assigned: " + recordAudioSource.clip.name);
    }

    if (recordAudioSource != null && placedVinyl != null)
    {
        Debug.Log("Vinyl placed, playing song: " + placedVinyl.vinylSong.name);
        recordAudioSource.clip = placedVinyl.vinylSong;  // Set the vinyl's specific song
        recordAudioSource.Play();  // Play the song
    }
    isVinylPlaying = true;

    needle.transform.position = new Vector3(needle.transform.position.x, vinylSlot.position.y, needle.transform.position.z); // Set initial position
}


    public void OnVinylRemoved()
    {
        // Stop the music when the vinyl is removed
        if (recordAudioSource != null)
        {
            recordAudioSource.Stop();
        }
        isVinylPlaying = false;

        // Reset the needle to its original position
        needle.transform.position = needleOriginalPosition;
    }

    // Test method: Call this manually to test if the song plays
    void TestPlaceVinyl()
    {
        Vinyl placedVinyl = vinyl.GetComponent<Vinyl>();  // Get the Vinyl script attached to the vinyl object
        OnVinylPlaced(placedVinyl);  // Call the OnVinylPlaced method
    }
}
