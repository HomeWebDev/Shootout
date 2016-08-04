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

        gameObject.SetActive(false);
    }

    //void Awake()
    //{
    //    playerMovement = GetComponent<Animation_Controller>();
    //}
}
