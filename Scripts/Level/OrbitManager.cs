using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitManager : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    FaceVariable currentFace;
#pragma warning restore 0649
    private readonly static Vector3[] rotations = { new Vector3(0,0,0),
        new Vector3(0, 90f, 0), new Vector3(0, 180f, 0), new Vector3(0, -90f, 0) };
    private readonly static float[] xMinLimit = {  -90f,0f,90f,0f};
    private readonly static float[] xMaxLimit = { 90f, -180f, 270f, 180f };
    DragMouseOrbit orbit;
    public void Awake()
    {
        orbit = gameObject.GetComponent<DragMouseOrbit>();
    }
    public void OnEnable()
    {
        SetOrbitManager();
    }
    public void SetOrbitManager()
    {
        Debug.Log(rotations[(int)currentFace.Value]);
        gameObject.transform.rotation = Quaternion.Euler(rotations[(int) currentFace.Value]);
        //orbit.xMinLimit = xMinLimit[(int) currentFace.Value];
        //orbit.xMaxLimit = xMaxLimit[(int)currentFace.Value];
    }
}
