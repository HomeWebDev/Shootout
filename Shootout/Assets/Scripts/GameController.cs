using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public int player1HealthValue;
    public int player2HealthValue;
    public int player3HealthValue;
    public int player4HealthValue;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    private GameObject player1Clone;
    private GameObject player2Clone;
    private GameObject player3Clone;
    private GameObject player4Clone;

    private PlayerHealth player1Health;

    // Use this for initialization
    void Start () {

        //player1Clone = Instantiate(player1, new Vector3(9, 0, -9), Quaternion.identity) as GameObject;
        //player2Clone = Instantiate(player2, new Vector3(-9, 0, 9), Quaternion.identity) as GameObject;
        //player3Clone = Instantiate(player3, new Vector3(-9, 0, -9), Quaternion.identity) as GameObject;
        //player4Clone = Instantiate(player4, new Vector3(9, 0, 9),  Quaternion.identity) as GameObject;

        //player1Health.health = player1HealthValue;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void KillPlayer(int playerID)
    {
        print("Player killed:" + Time.time);
    }
}
