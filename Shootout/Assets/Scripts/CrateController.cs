using UnityEngine;
using System.Collections;

public class CrateController : MonoBehaviour
{
    public int health = 3;

    public Transform ItemSpawn;
    public GameObject CrateItem;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(Collider other, int amount)
    {
        // Decrement the player's health by amount.
        health -= amount;

        if (health <= 0)
        {
            //Destroy(gameObject);
            CrateItem.tag = this.tag;
            Instantiate(CrateItem, gameObject.transform.position, ItemSpawn.rotation);
            Destroy(gameObject);
        }

    }
}
