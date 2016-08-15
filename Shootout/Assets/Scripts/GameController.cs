using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public static int Player1Kills;
    public static int Player2Kills;
    public static int Player3Kills;
    public static int Player4Kills;

    public static int nrOfPlayers;

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

    private UnityEngine.UI.Text player1KillsText;
    private UnityEngine.UI.Text player2KillsText;
    private UnityEngine.UI.Text player3KillsText;
    private UnityEngine.UI.Text player4KillsText;

    // Use this for initialization
    void Start () {

        //player1Clone = Instantiate(player1, new Vector3(9, 0, -9), Quaternion.identity) as GameObject;
        //player2Clone = Instantiate(player2, new Vector3(-9, 0, 9), Quaternion.identity) as GameObject;
        //player3Clone = Instantiate(player3, new Vector3(-9, 0, -9), Quaternion.identity) as GameObject;
        //player4Clone = Instantiate(player4, new Vector3(9, 0, 9),  Quaternion.identity) as GameObject;

        //player1Health.health = player1HealthValue;

        //guiText = GameObject.Find("GUI_TEXT_NAME").guiText;

        //guiText = GetComponent<GUIText>;

        GameObject player1KillsTextGameObject = GameObject.Find("Player1Kills");
        player1KillsText = player1KillsTextGameObject.GetComponent<UnityEngine.UI.Text>();

        GameObject player2KillsTextGameObject = GameObject.Find("Player2Kills");
        player2KillsText = player2KillsTextGameObject.GetComponent<UnityEngine.UI.Text>();

        if (nrOfPlayers > 2)
        {
            GameObject player3KillsTextGameObject = GameObject.Find("Player3Kills");
            player3KillsText = player3KillsTextGameObject.GetComponent<UnityEngine.UI.Text>();
        }
        else
        {
            //Disable player 3 and 4
            GameObject player3GameObject = GameObject.Find("Player3");
            player3GameObject.SetActive(false);
            GameObject player4GameObject = GameObject.Find("Player4");
            player4GameObject.SetActive(false);

            GameObject rightTopPanelGameObject = GameObject.Find("RightTopPanel");
            rightTopPanelGameObject.SetActive(false);
            GameObject leftBottomPanelGameObject = GameObject.Find("LeftBottomPanel");
            leftBottomPanelGameObject.SetActive(false);
        }

        if (nrOfPlayers > 3)
        {
            GameObject player4KillsTextGameObject = GameObject.Find("Player4Kills");
            player4KillsText = player4KillsTextGameObject.GetComponent<UnityEngine.UI.Text>();
        }
        else
        {
            //Disable player 4
            GameObject player4GameObject = GameObject.Find("Player4");
            player4GameObject.SetActive(false);

            GameObject leftBottomPanelGameObject = GameObject.Find("LeftBottomPanel");
            leftBottomPanelGameObject.SetActive(false);
        }

    }
	
	// Update is called once per frame
	void Update () {
        UpdateKillCount();
    }

    private void UpdateKillCount()
    {
        player1KillsText.text = "Kills: " + Player1Kills;
        player2KillsText.text = "Kills: " + Player2Kills;
        if (nrOfPlayers > 2)
        {
            player3KillsText.text = "Kills: " + Player3Kills;

        }
        if (nrOfPlayers > 3)
        {
            player4KillsText.text = "Kills: " + Player4Kills;
        }
    }

    public void KillPlayer(int playerID)
    {
        print("Player killed:" + Time.time);
    }
}
