using UnityEngine;

public class RecordPlayerController : MonoBehaviour
{
    public AudioSource audioSource;  // The audio source to play the song
    public Transform vinylSocket;   // The position where the vinyl should be placed
    public GameObject currentVinyl; // The vinyl currently on the player
    private bool vinylPlaced = false; // Check if a vinyl is already placed

    void Start()
    {
        audioSource.loop = false; // The song shouldn't loop
    }

    // Call this when vinyl is placed
  public void PlaceVinyl(GameObject vinyl)
{
    if (!vinylPlaced)
    {
        VinylData vinylData = vinyl.GetComponent<VinylData>();
        if (vinylData != null)
        {
            audioSource.clip = vinylData.song; 
        }

        vinyl.transform.SetParent(vinylSocket);
        vinyl.transform.localPosition = new Vector3(0, 0.1f, 0);
        currentVinyl = vinyl;
        audioSource.Play();

        RotateObject rotateScript = vinyl.GetComponent<RotateObject>();
        if (rotateScript != null)
        {
            rotateScript.SetIsRotating(true);
            Debug.Log("SetIsRotating(true) called on: " + vinyl.name);
        }
        else
        {
            Debug.LogWarning("RotateObject script not found on: " + vinyl.name);
        }

        vinylPlaced = true;
    }
}


    // Call this when vinyl is removed
    public void RemoveVinyl()
    {
        if (vinylPlaced && currentVinyl != null)
        {
            // Stop rotation using RotateObject script
            RotateObject rotateScript = currentVinyl.GetComponent<RotateObject>();
            if (rotateScript != null)
            {
                rotateScript.SetIsRotating(false);
            }

            audioSource.Stop(); // Stop the music

            // Reset Parent so it can be grabbed again
            currentVinyl.transform.SetParent(null);
            currentVinyl = null;
            vinylPlaced = false; // Allow new vinyl to be placed

            Debug.Log("Vinyl removed and stopped spinning.");
        }
    }
}
