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

        GameObject record = attachedObjectTransform.gameObject;

        RotateObject rotateObject = record.GetComponent<RotateObject>();

        if (rotateObject != null)

        {

            rotateObject.SetIsRotating(true);

        }

    }

}