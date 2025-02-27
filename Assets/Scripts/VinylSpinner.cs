using UnityEngine;

public class VinylSpinner : MonoBehaviour
{
    public float spinSpeed = 20f;
    private bool isSpinning = false;
void Update()
{
    if (isSpinning)
    {
        transform.Rotate(0, 1, 0);  
    }
}




    public void StartSpinning()
    {
        isSpinning = true;
        Debug.Log("Vinyl is spinning.");
    }

    public void StopSpinning()
    {
        isSpinning = false;
        Debug.Log("Vinyl stopped spinning.");
    }
}

