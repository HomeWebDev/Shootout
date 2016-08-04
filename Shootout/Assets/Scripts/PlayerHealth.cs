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


        //PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        //other.GetComponent<>

        

        //print("Health reduced by: " + amount);
    }

    //void Awake()
    //{
    //    playerMovement = GetComponent<Animation_Controller>();
    //}
}
