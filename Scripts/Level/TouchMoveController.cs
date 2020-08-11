using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using StaticData;

public class TouchMoveController : MonoBehaviour
{
#pragma warning disable 0649
    [SerializeField]
    UnityEvent OnMouseUpEvent;
    [SerializeField]
    UnityEvent OnMouseDownEvent;
#pragma warning restore 0649
    static Vector3 highlightScale = new Vector3(0.05f, 0.05f, 0.05f);
    Vector3 gridBound;
    Vector3 gridUnit;
    Vector3 offset;
    float hiddenCoordVal;
    Vector3 extent;
    Vector3 oldScale;
    void Start()
    {
        gridBound = new Vector3(Grid3d.Bounds.x, Grid3d.Bounds.y, Grid3d.Bounds.z);
        gridUnit = new Vector3(Grid3d.Unit.x, Grid3d.Unit.y, Grid3d.Unit.z);
        extent = transform.GetComponent<MeshRenderer>().bounds.extents; //extents = size of properties / 2
        //Debug.Log(extent);
        oldScale = transform.localScale;
    }

    private void OnMouseDown()
    {
        hiddenCoordVal = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseAsWorldPoint();
        transform.localScale += highlightScale;
        OnMouseDownEvent.Invoke();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + offset;
    }

    private void OnMouseUp()
    {
        transform.localScale = oldScale;
        //dont let object go outside boundry
        Vector3 newPos = transform.position;
        newPos = LimitInBounds(newPos, extent, gridBound);
        //snap object to grid
        newPos = SnapToUnit(newPos, gridUnit);
        transform.position = newPos;
        OnMouseUpEvent.Invoke();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = hiddenCoordVal;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    private Vector3 LimitInBounds(Vector3 pos, Vector3 extent, Vector3 gridBound)
    {
        Vector3 boundedPos = new Vector3();
        for (int i = 0; i < 3; i++)
            boundedPos[i] = LimitInBounds(pos[i], extent[i], gridBound[i]);
        return boundedPos;
    }

    private float LimitInBounds(float position, float extent,float gridBound)
    {
        return Mathf.Clamp(position, gridBound * -1 + extent, gridBound - extent);
    }

    private Vector3 SnapToUnit(Vector3 pos, Vector3 gridUnit)
    {
        Vector3 unitPos = new Vector3();
        for (int i = 0; i < 3; i++)
            unitPos[i] = SnapToUnit(pos[i], gridUnit[i]);
        return unitPos;
    }

    private float SnapToUnit(float position,float gridUnit)
    {
        return (Mathf.Round(position / gridUnit) * gridUnit);
    }
}