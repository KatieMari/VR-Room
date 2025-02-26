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
    Vector3 currentRotation = transform.eulerAngles; // Get current global rotation

    Debug.Log("Rotating: " + gameObject.name + " - Rotation before: " + currentRotation);

    // ✅ Force rotation only on the Y-axis, keeping X/Z unchanged
    transform.rotation = Quaternion.Euler(0, currentRotation.y + ((sensitivity * speed) * Time.deltaTime), 0);

    Debug.Log("Rotating: " + gameObject.name + " - Rotation after: " + transform.eulerAngles);
}


}
