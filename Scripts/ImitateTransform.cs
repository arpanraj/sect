using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImitateTransform : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    GameObject target;
#pragma warning restore 0649

    private void Update()
    {
        Imitate();
    }
    public void Imitate()
    {
        target.transform.position = transform.position;
        target.transform.rotation = transform.rotation;
    }
    
}
