using System.Collections.Generic;
using UnityEngine;

public class ShapeIdentifier : MonoBehaviour
{
    public int id;

    public void SetIdToVariable(IntVariable variable)
    {
        Debug.Log("TouchDown");
        Debug.Log(id);
        variable.Value = id;
    }
}