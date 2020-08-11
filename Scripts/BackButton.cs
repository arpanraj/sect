using UnityEngine;
using UnityEngine.SceneManagement;
using StaticData;

public class BackButton : MonoBehaviour
{
    private string GetPreviousScene()
    {
        string scene = SceneManager.GetActiveScene().name;

        if (scene == SceneNames.START  || scene == SceneNames.PRELOAD)
            return "Quit";
        else if (scene == SceneNames.OPTIONS)
            return SceneNames.START;
        else if (scene == SceneNames.LEVELS)
            return SceneNames.START;
        else if (scene == SceneNames.SETTINGS)
            return SceneNames.OPTIONS;
        else if (scene == SceneNames.CONNECT)
            return SceneNames.OPTIONS;
        else if (scene == SceneNames.SUPPORT)
            return SceneNames.OPTIONS;
        else
            return SceneNames.LEVELS;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            string previousScene = GetPreviousScene();
            if(previousScene == "Quit")
            {
                Application.Quit();
                return;
            }
            SceneManager.LoadScene(previousScene);
        }
    }
}