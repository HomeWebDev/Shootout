using UnityEngine;
using System.Collections;

public class ShieldPickup : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.name != "Bolt(Clone)")
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.AddShield(50);
            Destroy(gameObject);
        }
    }
}
