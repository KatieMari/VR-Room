using UnityEngine;

public class Vinyl : MonoBehaviour
{
    public AudioClip vinylSong; // The song assigned to the vinyl

    void Start()
    {
        if (vinylSong == null)
        {
            Debug.LogError("Vinyl Song is not assigned!");
        }
        else
        {
            Debug.Log("Vinyl Song assigned: " + vinylSong.name);
        }
    }
}
