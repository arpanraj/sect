using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShareManager : MonoBehaviour
{
    public void shareText(StringVariable text)
    {
        StartCoroutine(shareText(text.Value));
    }
    private IEnumerator shareText(string text)
    {
        yield return null;
        new NativeShare().SetText(text).Share();
    }
    
}
