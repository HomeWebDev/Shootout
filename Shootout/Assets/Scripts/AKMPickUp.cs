using UnityEngine;
using System.Collections;

public class AKMPickUp : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1" && other.name != "Bolt(Clone)")
        {
            other.GetComponent<Animation_Controller>().weapon = new GameObject();
            other.GetComponent<Animation_Controller>().weapon.tag = "AKM";
            Destroy(gameObject);
        }
    }
}
