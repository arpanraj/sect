using UnityEngine;
[CreateAssetMenu]
public class DirectionVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string Description = "";
#endif
    public Direction Value;

    public void SetValue(Direction value)
    {
        Value = value;
    }

    public Direction GetValue()
    {
        return Value;
    }
}
