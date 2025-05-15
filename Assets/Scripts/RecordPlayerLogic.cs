using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecordPlayerLogic : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;                // Assign this in the inspector
    public RecordPlayerController recordPlayer;      // Assign this too

    void OnEnable()
    {
        // Subscribe to the event when something is inserted into the socket
        socket.selectEntered.AddListener(OnVinylPlaced);
    }

    void OnDisable()
    {
        // Unsubscribe to avoid memory leaks or errors
        socket.selectEntered.RemoveListener(OnVinylPlaced);
    }

    private void OnVinylPlaced(SelectEnterEventArgs args)
    {
        GameObject vinyl = args.interactableObject.transform.gameObject;

        // Call the method to handle playing the vinyl
        recordPlayer.PlaceVinyl(vinyl);
    }
}
