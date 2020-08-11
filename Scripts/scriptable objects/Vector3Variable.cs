using UnityEngine;

[CreateAssetMenu]
public class Vector3Variable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string Description = "";
#endif
    public Vector3 Value;

    public void SetValue(Vector3 value)
    {
        Value = value;
    }

    public Vector3 GetValue()
    {
        return Value;
    }
}
