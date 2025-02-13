using UnityEngine;

public class ClockTurn : MonoBehaviour
{
float rotateSpeed;
float secSpeed;
float hourSpeed;
public GameObject minHand;
public GameObject hourHand;
public GameObject secHand;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotateSpeed = Time.deltaTime/60f;
        secSpeed = 360f/60f;
        hourSpeed = rotateSpeed/12;
    }

    // Update is called once per frame
    void Update()
    {
        float s = Time.deltaTime;
        minHand.transform.Rotate(rotateSpeed, 0, 0, Space.World);
        secHand.transform.Rotate(secSpeed*Time.deltaTime, 0, 0, Space.World);
        hourHand.transform.Rotate(hourSpeed, 0, 0, Space.World);
    }
}
 