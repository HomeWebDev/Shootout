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

    public void TakeDamage(Collider other, int amount, GameObject bullet)
    {
        // Decrement the player's health by amount.
        health -= amount;

        healthSlider.value = health;

        if (health <= 0)
        {
            PlayerKilled();

            //print(bullet.tag);

            if (bullet.tag == "Player1")
            {
                GameController.Player1Kills++;
            }
            if (bullet.tag == "Player2")
            {
                GameController.Player2Kills++;
            }
            if (bullet.tag == "Player3")
            {
                GameController.Player3Kills++;
            }
            if (bullet.tag == "Player4")
            {
                GameController.Player4Kills++;
            }

            //Game ends when first player has 5 kills
            if (GameController.Player1Kills > 4 | GameController.Player2Kills > 4 | GameController.Player3Kills > 4 | GameController.Player4Kills > 4)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("ResultScene");

                //Update score texts
                UpdateScoreTexts();

            }

            //print("Number of kills: " + GameController.Player1Kills);
        }


        //PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        //other.GetComponent<>

        

        //print("Health reduced by: " + amount);
    }

    private void UpdateScoreTexts()
    {
        if (GameController.nrOfPlayers == 2)
        {
            if (GameController.Player2Kills > GameController.Player1Kills)
            {
                GameObject firstPlayerTextGameObject = GameObject.Find("FirstPlayerText");
                UnityEngine.UI.Text firstPlayerText = firstPlayerTextGameObject.GetComponent<UnityEngine.UI.Text>();
                firstPlayerText.text = "1. Player 2 with " + GameController.Player2Kills + " kills";

                GameObject secondPlayerTextGameObject = GameObject.Find("SecondPlayerText");
                UnityEngine.UI.Text secondPlayerText = secondPlayerTextGameObject.GetComponent<UnityEngine.UI.Text>();
                secondPlayerText.text = "2. Player 1 with " + GameController.Player1Kills + " kills";
            }
            else
            {
                GameObject firstPlayerTextGameObject = GameObject.Find("FirstPlayerText");
                UnityEngine.UI.Text firstPlayerText = firstPlayerTextGameObject.GetComponent<UnityEngine.UI.Text>();
                firstPlayerText.text = "2. Player 1 with " + GameController.Player1Kills + " kills";

                GameObject secondPlayerTextGameObject = GameObject.Find("SecondPlayerText");
                UnityEngine.UI.Text secondPlayerText = secondPlayerTextGameObject.GetComponent<UnityEngine.UI.Text>();
                firstPlayerText.text = "1. Player 2 with " + GameController.Player2Kills + " kills";
            }
            GameObject thirdPlayerTextGameObject = GameObject.Find("ThirdPlayerText");
            UnityEngine.UI.Text thirdPlayerText = thirdPlayerTextGameObject.GetComponent<UnityEngine.UI.Text>();
            thirdPlayerText.text = "";

            GameObject fourthPlayerTextGameObject = GameObject.Find("FourthPlayerText");
            UnityEngine.UI.Text fourthPlayerText = fourthPlayerTextGameObject.GetComponent<UnityEngine.UI.Text>();
            fourthPlayerText.text = "";
        }
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
            gameObject.transform.position = new Vector3(13, 0, -13);
        }
        if (gameObject.tag == "Player2")
        {
            gameObject.transform.position = new Vector3(-13, 0, 13);
        }
        if (gameObject.tag == "Player3")
        {
            gameObject.transform.position = new Vector3(-13, 0, -13);
        }
        if (gameObject.tag == "Player4")
        {
            gameObject.transform.position = new Vector3(13, 0, 13);
        }

        render.enabled = true;
    }

    //void Awake()
    //{
    //    playerMovement = GetComponent<Animation_Controller>();
    //}
}
