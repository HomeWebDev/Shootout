using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

    public int health = 100;

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

    public void TakeDamage(int amount)
    {
        // Decrement the player's health by amount.
        health -= amount;



        //print("Health reduced by: " + amount);
    }

    //void Awake()
    //{
    //    playerMovement = GetComponent<Animation_Controller>();
    //}
}
