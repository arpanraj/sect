using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level4Tutorial : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private GameObject pointer;
    [SerializeField]
    private UnityEvent OnTutorialComplete;
#pragma warning restore 0649

    private Animator pointerAnimator;
    bool isLeftSwipeDone = false;
    bool isRightSwipeDone = false;

    private void Start()
    {
        pointerAnimator = pointer.GetComponent<Animator>();
    }
    public void ChangeDirection(DirectionVariable direction)
    {

        if(direction.Value == Direction.left)
        {
            RightSideMoved();
        }
        else
        {
            LeftSideMoved();
        }
        if (isLeftSwipeDone & isRightSwipeDone)
        {
            OnTutorialComplete.Invoke();
        }
    }

    private void LeftSideMoved()
    {
        if (!isLeftSwipeDone)
        {
            pointerAnimator.SetTrigger("Level4Move2");
            isLeftSwipeDone = true;
        }
    }

    private void RightSideMoved()
    {
        if (!isRightSwipeDone)
        {
            pointerAnimator.SetTrigger("Level4Move1");
            isRightSwipeDone = true;
        }
    }
}
