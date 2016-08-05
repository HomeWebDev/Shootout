using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int health = 100;

    public Slider healthSlider;

    //private Animation_Controller playerMovement;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ResetHealth()
    {
        //Reset health
        health = 100;

        healthSlider.value = health;
    }

    public void TakeDamage(Collider other, int amount)
    {
        // Decrement the player's health by amount.
        health -= amount;

        healthSlider.value = health;

        if (health <= 0)
        {
            PlayerKilled();
        }


        //PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        //other.GetComponent<>

        

        //print("Health reduced by: " + amount);
    }

    private void PlayerKilled()
    {
        //Destroy(gameObject);

        //gameObject.SetActive(false);


        //GameController gameController = GetComponent<GameController>();



        //gameController.KillPlayer(2);


        StartCoroutine(Respawn());
    }


    IEnumerator Respawn()
    {

        //print("Set inactive:" + Time.time);
        //gameObject.SetActive(false);

        SkinnedMeshRenderer render = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();

        render.enabled = false;
        gameObject.transform.position = new Vector3(99, 0, -99);

        yield return new WaitForSeconds(5);

        //print("Set active:" + Time.time);
        //gameObject.SetActive(true);

        ResetHealth();

        if (gameObject.tag == "Player1")
        {
            gameObject.transform.position = new Vector3(9, 0, -9);
        }
        if (gameObject.tag == "Player2")
        {
            gameObject.transform.position = new Vector3(-9, 0, 9);
        }
        if (gameObject.tag == "Player3")
        {
            gameObject.transform.position = new Vector3(-9, 0, -9);
        }
        if (gameObject.tag == "Player4")
        {
            gameObject.transform.position = new Vector3(9, 0, 9);
        }

        render.enabled = true;
    }

    //void Awake()
    //{
    //    playerMovement = GetComponent<Animation_Controller>();
    //}
}
