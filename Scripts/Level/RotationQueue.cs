using UnityEngine;

public class RotationQueue : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    DirectionVariable direction;

#pragma warning restore 0649
    int index = 0;
    int max;

    private readonly static Vector3[] rotations = { new Vector3(0,0,0),
        new Vector3(0, 90f, 0), new Vector3(0, 180f, 0), new Vector3(0, 270f, 0) };

    private void Awake()
    {
        max = rotations.Length;
        //SetQueue(rotations, QueueType.Circular);
    }

    public void OnDirectionChange()
    {
        if(direction.Value == Direction.left)
        {
            iTween.RotateTo(gameObject, PreviousRotation(), 1);
        }
        else
        {
            iTween.RotateTo(gameObject, NextRotation(), 1);
        }
    }

    private Vector3 NextRotation()
    {
        index++;
        if (index == max)
        {
            index = 0;
        }
        return rotations[index];
    }

    private Vector3 PreviousRotation()
    {
        index--;
        if (index == -1)
        {
            index = max - 1;
        }
        return rotations[index];
    }
}
