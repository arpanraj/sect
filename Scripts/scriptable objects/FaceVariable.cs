using UnityEngine;
[CreateAssetMenu]

public class FaceVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string Description = "";
#endif
    public Face Value;

    public void SetValue(Face value)
    {
        Value = value;
    }

    public Face GetValue()
    {
        return Value;
    }
}
