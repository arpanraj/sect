using UnityEngine;
using UnityEngine.Events;
public class AnimatorManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    UnityEvent OnAnimationCompleted;

#pragma warning restore 0649

    public void OnAnimationComplete()
    {
        OnAnimationCompleted.Invoke();
    }
}
