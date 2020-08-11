using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class OutlineQueue : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private Material[] outlineMaterial;
    [SerializeField]
    private UnityEvent onOutlinesComplete;
#pragma warning restore 0649
    List<Renderer> renderers;
    int index = 0;
    int max;

    private void Awake()
    {
        max = transform.childCount;
        renderers = new List<Renderer>();
        for(int i = 0;i < max;i++)
        {
            renderers.Add(transform.GetChild(i).GetComponent<Renderer>());
        }
        
    }
    

    public void NextOutline()
    {
        index++;
        renderers[index - 1].material = outlineMaterial[index- 1];
        if (index == max)
        {
            onOutlinesComplete.Invoke();
        }
    }
    
}
