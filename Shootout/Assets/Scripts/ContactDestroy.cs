using UnityEngine;
using System.Collections;

public class ContactDestroy : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        Destroy(other.gameObject);
        Destroy(gameObject);

        GameObject tmp = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        Destroy(tmp, 1);

        if (other.tag == "Player")
        {
            tmp = Instantiate(playerExplosion, other.transform.position, other.transform.rotation) as GameObject;
            Destroy(tmp, 1);
        }
    }
}
