using UnityEngine;

public class RecordPlayerController : MonoBehaviour
{
    public AudioSource audioSource;  // The audio source to play the song
    public Transform vinylSocket;   // The position where the vinyl should be placed
    public GameObject currentVinyl; // The vinyl currently on the player
    private bool vinylPlaced = false; // Check if a vinyl is already placed

    // Call this when vinyl is placed
    public void PlaceVinyl(GameObject vinyl)
{
    if (!vinylPlaced)
    {
        Vinyl vinylData = vinyl.GetComponent<Vinyl>();
        if (vinylData != null)
        {
            audioSource.clip = vinylData.song;
        }

        // Set position & rotation
        vinyl.transform.SetParent(vinylSocket);
        vinyl.transform.localPosition = new Vector3(0, 0.1f, 0);
    
        currentVinyl = vinyl;
        audioSource.Play();

        RotateObject rotateScript = vinyl.GetComponent<RotateObject>();
        if (rotateScript != null)
        {
            rotateScript.SetIsRotating(true);
            rotateScript.enabled = true;
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
        RotateObject rotateScript = currentVinyl.GetComponent<RotateObject>();
        if (rotateScript != null)
        {
            rotateScript.SetIsRotating(false);
            rotateScript.enabled = false;
        }

        audioSource.Stop();

        currentVinyl.transform.SetParent(null);
        currentVinyl = null;
        vinylPlaced = false;

        Debug.Log("Vinyl removed and song stopped.");
    }
}

}