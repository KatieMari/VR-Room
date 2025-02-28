using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit.Interactables;

using UnityEngine.XR.Interaction.Toolkit.Interactors;



public class RecordPlayerLogic : MonoBehaviour

{

    XRSocketInteractor socket;

    IXRSelectInteractor interactor;

    void Start()

    {

        interactor = GetComponent<IXRSelectInteractor>();

    }

    public void SocketCheck()

    {

        IXRSelectInteractable interactable = interactor.firstInteractableSelected;

        Transform attachedObjectTransform = interactable.transform;

        GameObject vinyl = attachedObjectTransform.gameObject;

        RotateObject rotateObject = vinyl.GetComponent<RotateObject>();

        if (rotateObject != null)

        {

            rotateObject.SetIsRotating(true);

        }

    }

}