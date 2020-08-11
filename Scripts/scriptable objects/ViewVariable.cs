using UnityEngine;
[CreateAssetMenu]
public class ViewVariable : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline]
    public string Description = "";
#endif
    public View Value;

    public void SetValue(View value)
    {
        Value = value;
    }

    public View GetValue()
    {
        return Value;
    }
}
