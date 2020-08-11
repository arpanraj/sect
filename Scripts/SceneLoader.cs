using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
public class SceneLoader : MonoBehaviour
{

    public void Load(StringVariable sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad.Value);
    }
    public void Load(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
