using UnityEngine;
using UnityEngine.Events;

public class ViewManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    ViewVariable view;
    [SerializeField]
    UnityEvent OnProblmeViewSwitch;
    [SerializeField]
    UnityEvent OnSolutionViewSwitch;
#pragma warning restore 0649
    
    public void InvokeView()
    {
        if (view.Value == View.solution)
        {
            OnSolutionViewSwitch.Invoke();
        }
        else
        {
            OnProblmeViewSwitch.Invoke();
        }
    }
}
