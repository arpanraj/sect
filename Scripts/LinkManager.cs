using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkManager : MonoBehaviour
{
    public void Open(string link)
    {
        Application.OpenURL(link);
    }
    public void Open(StringVariable link)
    {
        Application.OpenURL(link.Value);
    }

    public void OpenGamePage()
    {
        Application.OpenURL("market://details?id=" + Application.identifier);
    }
}
