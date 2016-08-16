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
        // Decrement the crates health by amount.
        health -= amount;

        if (health <= 0)
        {
            //Destroy(gameObject);
            
            if (Random.value > 0.0 & other.tag == "ItemCrate")
            {
                CrateItem.tag = "AKM";
                Vector3 onFLoorPosition = gameObject.transform.position + new Vector3(0, -0.5f, 0);
                CrateItem = Instantiate(CrateItem, onFLoorPosition, ItemSpawn.rotation) as GameObject;
                //CrateItem.AddComponent<BoxCollider>();
                CrateItem.AddComponent<AKMPickUp>();
                CrateItem.AddComponent<BoxCollider>();
                CrateItem.GetComponent<BoxCollider>().isTrigger = true;
            }

            //CrateItem.AddComponent<BoundaryDestroy>();
            Destroy(gameObject);
        }

    }
}
