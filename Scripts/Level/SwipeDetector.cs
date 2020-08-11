using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    left,
    right
}

public class SwipeDetector : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    private bool detectSwipeOnlyAfterRelease = false;
    [SerializeField]
    private float minDistanceForSwipe = 20f;
    [SerializeField]
    private DirectionVariable swipeDirection;
    [SerializeField]
    private UnityEvent onSwipe;
#pragma warning restore 0649
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    private void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                fingerUpPosition = touch.position;
                fingerDownPosition = touch.position;
            }

            if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }

            if (touch.phase == TouchPhase.Ended)
            {
                fingerDownPosition = touch.position;
                DetectSwipe();
            }
        }
    }

    private void DetectSwipe()
    {
        if (SwipeDistanceCheckMet())
        {
            if(IsHorizontalSwipe())
            {
                var direction = fingerDownPosition.x - fingerUpPosition.x > 0 ? Direction.right : Direction.left;
                SendSwipe(direction);
            }
            fingerUpPosition = fingerDownPosition;
        }
    }


    private bool IsHorizontalSwipe()
    {
        return VerticalMovementDistance() < HorizontalMovementDistance();
    }

    private bool SwipeDistanceCheckMet()
    {
        return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
    }

    private float VerticalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
    }

    private float HorizontalMovementDistance()
    {
        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);
    }

    private void SendSwipe(Direction direction)
    {
        swipeDirection.Value = direction;
        onSwipe.Invoke();
    }
}
