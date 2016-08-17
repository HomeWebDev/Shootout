using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour
{

    // Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update () {

    //}

    //public void LoadScene(int level)
    //{
    //    print("test");
    //    Application.LoadLevel(level);

    //}

    public void LoadScene(string sceneName)
    {
        //print("test2");

        if (sceneName == "scene4players")
        {
            GameController.nrOfPlayers = 4;
        }
        if (sceneName == "scene3players")
        {
            GameController.nrOfPlayers = 3;
        }
        if (sceneName == "scene2players")
        {
            GameController.nrOfPlayers = 2;
        }
        if (sceneName == "IntroScene")
        {
            //Reset number of kills
            GameController.Player1Kills = 0;
            GameController.Player2Kills = 0;
            GameController.Player3Kills = 0;
            GameController.Player4Kills = 0;

            UnityEngine.SceneManagement.SceneManager.LoadScene("IntroScene");
        }
        else if (sceneName == "ControlsScene")
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("ControlsScene");
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("scene4players");
        }





        //UnityEngine.SceneManagement.SceneManager.LoadScene("scene1");
    }

    //public void LoadScene(int sceneBuildIndex, UnityEngine.SceneManagement.LoadSceneMode mode = UnityEngine.SceneManagement.LoadSceneMode.Single)
    //{
    //    print("test");

    //    UnityEngine.SceneManagement.SceneManager.LoadScene(sceneBuildIndex);
    //}

    //void LoadScene()
    //{
    //    print("test");
    //}

}