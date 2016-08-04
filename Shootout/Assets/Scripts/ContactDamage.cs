using UnityEngine;
using System.Collections;

public class ContactDamage : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    private 

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        if (other.tag == this.tag)
        {
            return;
        }
        //else
        //{
        //    print("Other: " + other.tag.ToString() + " This: " + this.tag.ToString());
        //}



        //Destroy(other.gameObject);

        //health = health - 10;

        //Animation_Controller ac = new Animation_Controller;

        //ac.health 

        //print("Other: " + other.ToString());

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(other, 10);

        

        //playerMovement = GetComponent<Animation_Controller>();

        Destroy(gameObject);

        //GameObject tmp = Instantiate(explosion, transform.position, transform.rotation) as GameObject;
        //Destroy(tmp, 1);

        //if (other.tag == "Player1")
        //{
        //    tmp = Instantiate(playerExplosion, other.transform.position, other.transform.rotation) as GameObject;
        //    Destroy(tmp, 1);
        //}
    }
}
