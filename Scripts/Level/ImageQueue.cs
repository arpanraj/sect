using UnityEngine;
using UnityEngine.UI;

public class ImageQueue : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    Sprite[] images;
#pragma warning restore 0649
    int index = 0;
    int max;
    private void Awake()
    {
        max = images.Length;
    }

    public void NextImage()
    {
        index++;
        if (index == max)
        {
            index = 0;
        }
        this.GetComponent<Image>().sprite = images[index];
    }
    
    protected void SetImage(int index)
    {
        this.index = index;
        this.GetComponent<Image>().sprite = images[index];
    }
}
