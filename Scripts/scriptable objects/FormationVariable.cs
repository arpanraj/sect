using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FormationVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string Description = "";
#endif

    public List<List<Vector3>> Value;

    public void SetValue(List<List<Vector3>> value)
    {
        Value = value;
    }

    public List<List<Vector3>> GetValue()
    {
        return Value;
    }
}
