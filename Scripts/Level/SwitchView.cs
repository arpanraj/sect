using UnityEngine;
using UnityEngine.Events;

public enum View
{
    problem,
    solution
}

public class SwitchView : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    ViewVariable view;
    [SerializeField]
    UnityEvent onViewSwitched;
#pragma warning restore 0649

    private void Start()
    {
        view.Value = View.solution;   
    }

    public void Switch()
    {
        if (view.Value == View.problem)
        {
            view.Value = View.solution;
        }
        else
        {
            view.Value = View.problem;
        }
        onViewSwitched.Invoke();
    }
}
