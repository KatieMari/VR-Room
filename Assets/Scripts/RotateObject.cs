using UnityEngine;

/// <summary>
/// Set the rotation of an object
/// </summary>



public class RotateObject : MonoBehaviour
{
    [Tooltip("The value at which the speed is applied")]
    [Range(0, 1)] public float sensitivity = 1.0f;
    [Tooltip("The max speed of the rotation")]
    public float speed = 10.0f;
    private bool isRotating = false;
    public GameObject vinyl;

    public void Start()
    {
        vinyl = this.gameObject.transform.GetChild(0).gameObject;
    }

    public void SetIsRotating(bool value)
    {
        Debug.Log("SetIsRotating called with: " + value + " on " + gameObject.name);
        isRotating = value;
    }

    private void Update()
    {
        if (isRotating)
        {
            Debug.Log("Update Running: " + gameObject.name);
            Rotate();
        }
    }

    private void Rotate()
    {
        Vector3 currentRotation = transform.eulerAngles;
        Debug.Log("Rotating: " + gameObject.name + " - Rotation before: " + currentRotation);
        vinyl.transform.Rotate(0.0f, ((sensitivity * speed) * Time.deltaTime), 0.0f, Space.Self);
        Debug.Log("Rotating: " + gameObject.name + " - Rotation after: " + transform.eulerAngles);
    }

}
