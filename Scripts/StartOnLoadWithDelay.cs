using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class StartOnLoadWithDelay : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private UnityEvent OnStart;
    [SerializeField]
    private float delay;
#pragma warning restore 0649
    void Start()
    {
        StartCoroutine(DelayedInvoke(delay));
    }

    IEnumerator DelayedInvoke(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnStart.Invoke();
    }
}
