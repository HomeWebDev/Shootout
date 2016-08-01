using UnityEngine;
using System.Collections;

public class ReceiveDamage : MonoBehaviour {

    public string playerTag;

    void OnTriggerEnter(Collider other)
    {
        //if (playerTag != other.tag)
        //{
        //    Destroy(other.gameObject);
        //    Destroy(gameObject);
        //}
    }
}
