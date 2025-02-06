using UnityEngine;

public class CustomBubbles : MonoBehaviour

{
   [Tooltip("The object that will be spawned")]
   public GameObject prefab = null;
   [Tooltip("The transform where the object is spawned")]
   public Transform spawnTransform = null;
   public void Spawn()
   {
      // Creates Bubble
      GameObject bubble = Instantiate(prefab, spawnTransform.position, spawnTransform.rotation);
      //    Rotates Randomly
      bubble.transform.rotation = Random.rotation;
      //    Set Random Launch Speed
      float launchSpeed = Random.Range(0.5f, 1.5f);
      //  Creates Vector3 to Represent Forward Force
      Vector3 force = spawnTransform.forward * launchSpeed;
      bubble.GetComponent<Rigidbody>().AddForce(force);
      bubble.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)));
   }
}
 