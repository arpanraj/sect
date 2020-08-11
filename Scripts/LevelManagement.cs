using System;
using UnityEngine.SceneManagement;
using StaticData;

public static class LevelManagement
{

    public static int GetActiveLevel()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        return sceneToLevel(activeScene, SceneNames.LEVEL_PREFIX);
    }

    public static int sceneToLevel(string name, string levelPrefix)
    {
        //BaseLevel will throw error
        string level = name.Replace(levelPrefix, "");
        return Int16.Parse(level);
    }
}
