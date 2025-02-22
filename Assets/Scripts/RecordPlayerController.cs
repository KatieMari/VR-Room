using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecordPlayerController : MonoBehaviour
{
    public AudioSource recordAudioSource;  // The AudioSource on the record player
    public Transform vinylSlot;  // Where the vinyl should snap
    public GameObject needle;  // The needle object
    public float vinylRotationSpeed = 50f;  // Speed of vinyl rotation
    public float needleMoveSpeed = 2f;  // Speed of the needle movement
    private Vinyl currentVinyl;  // The currently placed vinyl
    private Vector3 needleOriginalPosition;  // Initial position of the needle
    private bool isPlaying = false;

    void Start()
    {
        needleOriginalPosition = needle.transform.position; // Store original needle position
        recordAudioSource.Stop(); // Ensure no music plays at start
        Debug.Log("Record Player Controller Initialized");
    }

    void Update()
    {
        if (isPlaying && currentVinyl != null)
        {
            // Rotate the vinyl while playing
            currentVinyl.transform.Rotate(Vector3.up, vinylRotationSpeed * Time.deltaTime);
            Debug.Log("Vinyl is rotating");

            // Move the needle onto the vinyl
            Vector3 targetPosition = new Vector3(needleOriginalPosition.x, needleOriginalPosition.y, vinylSlot.position.z);
            needle.transform.position = Vector3.MoveTowards(needle.transform.position, targetPosition, needleMoveSpeed * Time.deltaTime);
            Debug.Log("Needle is moving towards vinyl");
        }
    }

    // The method that is called when the vinyl is placed
    public void OnVinylPlaced(Vinyl placedVinyl)
    {
        if (placedVinyl == null)
        {
            Debug.LogError("No vinyl was placed on the player!");
            return; // Avoid null errors
        }

        // If there's already a vinyl on the player, remove it first
        if (currentVinyl != null)
        {
            OnVinylRemoved(); // Call the removal function to stop the current vinyl's music
        }

        Debug.Log("Vinyl placed on record player");

        // Assign the placed vinyl
        currentVinyl = placedVinyl;
        currentVinyl.transform.position = vinylSlot.position;
        currentVinyl.transform.rotation = vinylSlot.rotation;
        currentVinyl.gameObject.SetActive(true); // Make sure the vinyl is active when placed
        Debug.Log("Vinyl position and rotation set");

        // Assign and play the correct song
        if (recordAudioSource != null && currentVinyl.vinylSong != null)
        {
            recordAudioSource.clip = currentVinyl.vinylSong;
            recordAudioSource.Play();
            Debug.Log("Audio clip assigned and playing");
            isPlaying = true;
        }
        else
        {
            Debug.LogError("AudioSource or Vinyl Song is missing!");
        }
    }

    // The method to remove the vinyl from the player
    public void OnVinylRemoved()
    {
        if (recordAudioSource.isPlaying)
        {
            recordAudioSource.Stop();
            Debug.Log("Music stopped");
        }
        isPlaying = false;

        // Reset the needle
        needle.transform.position = needleOriginalPosition;
        Debug.Log("Needle reset to original position");

        // Optionally reset the vinyl's position or deactivate it here if needed
        if (currentVinyl != null)
        {
            currentVinyl.gameObject.SetActive(false); // Deactivate vinyl when removed
            currentVinyl = null; // Clear reference to the current vinyl
        }
    }
}
