using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLevelToLoad : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    IntVariable levelToLoad;
#pragma warning restore 0649
    public void Set(int levelNumber)
    {
        levelToLoad.Value = levelNumber;
    }
}
