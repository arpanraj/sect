using UnityEngine;
using StaticData;
public class FadeQueue : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    Animator[] animators;
#pragma warning restore 0649
    int index = 0;
    int max;
    private void Awake()
    {
        max = animators.Length;
    }

    public void CurrentFade()
    {
        animators[index].SetTrigger(Triggers.FADE_IN);
    }
    public void NextFade()
    {
        index++;
        if(index == max)
        {
            return;
        }
        animators[index].SetTrigger(Triggers.FADE_IN);
        
    }
}
