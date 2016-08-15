using UnityEngine;
using System.Collections;

public class ContactDamage : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;

    private 

    void OnTriggerEnter(Collider other)
    {

        //if (other.tag == "ItemCrate")
        //{
        //    print("crate");
        //}

        if (other.tag == "Boundary")
        {
            return;
        }

        //if (other.tag == "ItemCrate")
        //{
        //    return;
        //}

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

        if (other.tag == "ItemCrate")
        {
            print("crate");
            
            //Destroy(other.gameObject);
            CrateController crateDamage = other.GetComponent<CrateController>();
            crateDamage.TakeDamage(other, 1);
        }
        else
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(other, 10, gameObject);
        }



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
