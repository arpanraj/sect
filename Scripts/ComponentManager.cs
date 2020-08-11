using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    bool IsComponentActive;
    [SerializeField]
    MonoBehaviour component;
#pragma warning restore 0649

    public void SetActive(bool Active)
    {
        IsComponentActive = Active;
        component.enabled = IsComponentActive;
    }
    
    public void SetActiveWithDelay(bool value)
    {
        StartCoroutine(SetActiveWithDelayIE(value));   
    }
    public void SwitchActive()
    {
        IsComponentActive = !IsComponentActive;
        component.enabled = IsComponentActive;
    }
    IEnumerator SetActiveWithDelayIE(bool value)
    {
        yield return new WaitForSeconds(0.5f);
        IsComponentActive = value;
        component.enabled = IsComponentActive;
    } 
}
