using UnityEngine;
using System.Collections;

public class HeathPackPickup : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.name != "Bolt(Clone)")
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.AddHealth(50);
            Destroy(gameObject);
        }
    }
}
