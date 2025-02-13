using UnityEngine;

public class ClockTurn : MonoBehaviour
{
public float rotateSpeed;
public GameObject minHand;
public GameObject hourHand;
public GameObject secHand;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotateSpeed = Time.deltaTime/60f;
    }

    // Update is called once per frame
    void Update()
    {
        float s = Time.deltaTime;
        minHand.transform.Rotate(rotateSpeed, 0, 0, Space.World);
        secHand.transform.Rotate((360f/60f)*Time.deltaTime, 0, 0, Space.World);
        // hourHand.transform.Rotate(rotateSpeed/12, 0, 0, Space.World);
    }
}
 