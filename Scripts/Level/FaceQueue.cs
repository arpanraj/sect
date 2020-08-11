using UnityEngine;
using UnityEngine.UI;

public enum Face
{
    front,
    right,
    back,
    left,
}

public class FaceQueue : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    DirectionVariable direction;
    [SerializeField]
    Sprite[] faces;
#pragma warning restore 0649
    int index = 0;
    int max;
    private void Awake()
    {
        max = faces.Length;
    }

    public void OnDirectionChange()
    {
        if (direction.Value == Direction.left)
        {
            this.GetComponent<Image>().sprite = PreviousFace();
        }
        else
        {
            this.GetComponent<Image>().sprite = NextFace();
        }

    }
    private Sprite NextFace()
    {
        index++;
        if (index == max)
        {
            index = 0;
        }
        return faces[index];
    }
    private Sprite PreviousFace()
    {
        index--;
        if (index == -1)
        {
            index = max - 1;
        }
        return faces[index];
    }

    public void SetFace(FaceVariable face)
    {
        face.Value = (Face) index;
    }
}