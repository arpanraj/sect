using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using StaticData;
public class SetSceneToLoad : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    StringVariable sceneToLoad;
#pragma warning restore 0649

    public void Set(StringVariable stringVariable)
    {
        sceneToLoad.Value = stringVariable.Value;
    }

    public void Set(IntVariable levelNumber)
    {
        sceneToLoad.Value = SceneNames.LEVEL_PREFIX + levelNumber.Value.ToString();
    }

    public void SetNextLevel()
    {
        int nextLevel = LevelManagement.GetActiveLevel() + 1;
        sceneToLoad.Value = SceneNames.LEVEL_PREFIX + nextLevel.ToString();
    }
}
