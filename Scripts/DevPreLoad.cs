using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DevPreLoad : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    StringReference GameManagerName;
    [SerializeField]
    StringReference PreLoadName;
#pragma warning restore 0649

    void Awake()
    {
        GameObject check = GameObject.Find("SceneLoadManager");
        if (check == null)
        { SceneManager.LoadScene(PreLoadName); }
    }
}
