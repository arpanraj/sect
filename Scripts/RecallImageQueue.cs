using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticData;
public class RecallImageQueue : ImageQueue
{
#pragma warning disable 0649
    [SerializeField]
    IntVariable imageIndexrecall;
#pragma warning restore 0649

    private void Start()
    {
        SetImage(imageIndexrecall.Value);   
    }
    
    public new void NextImage()
    {
        base.NextImage();
    }
}
