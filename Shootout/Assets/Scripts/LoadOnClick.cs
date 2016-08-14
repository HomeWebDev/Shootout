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

        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);

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