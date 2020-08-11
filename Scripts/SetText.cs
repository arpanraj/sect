using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SetText : MonoBehaviour
{
    public void Set(StringVariable text)
    {
        gameObject.GetComponent<Text>().text = text.Value;
    }
}
