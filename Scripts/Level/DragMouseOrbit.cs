using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMouseOrbit : MonoBehaviour
{
    public Transform target;
    public float distance = 2.0f;
    public float xSpeed = 5f;
    public float ySpeed = 5f;
    public float yMinLimit = -90f;
    public float yMaxLimit = 90f;
    public float xMinLimit = -360f;
    public float xMaxLimit = 360f;
    public float distanceMin = 10f;
    public float distanceMax = 10f;
    public float smoothTime = 2f;
    float rotationYAxis = 0.0f;
    float rotationXAxis = 0.0f;
    float velocityX = 0.0f;
    float velocityY = 0.0f;
    Vector3 positionBefore;
    Quaternion rotationBefore;
    // Use this for initialization
    void OnEnable()
    {
        positionBefore = transform.position;
        rotationBefore = transform.rotation;
        Vector3 angles = transform.eulerAngles;
        rotationYAxis = angles.y;
        rotationXAxis = angles.x;
        // Make the rigid body not change rotation
        //if (GetComponent<Rigidbody>())
        //{
        //    GetComponent<Rigidbody>().freezeRotation = true;
        //}
    }

    private void OnDisable()
    {
        transform.position = positionBefore;
        transform.rotation = rotationBefore;
    }

    void Update()
    {
        if (target & ( Input.touchCount > 0))
        {
            if (Input.GetMouseButton(0))
            {
#if UNITY_EDITOR
                velocityX += xSpeed * Input.GetAxis("Mouse X") * distance * 0.2f;
                velocityY += ySpeed * Input.GetAxis("Mouse Y") * 0.2f;
#endif

#if UNITY_ANDROID
                if (Input.touchCount > 0)
                {
                    velocityX += xSpeed * Input.GetTouch(0).deltaPosition.x * distance * 0.02f;
                    velocityY += ySpeed * Input.GetTouch(0).deltaPosition.y * 0.02f;
                }
#endif
            }
            rotationYAxis += velocityX;
            rotationXAxis -= velocityY;
            rotationXAxis = ClampAngle(rotationXAxis, yMinLimit, yMaxLimit);
            //rotationYAxis = ClampAngle(rotationYAxis, xMinLimit, xMaxLimit);
            Quaternion fromRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
            Quaternion toRotation = Quaternion.Euler(rotationXAxis, rotationYAxis, 0);
            Quaternion rotation = toRotation;

            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);
            RaycastHit hit;
            if (Physics.Linecast(target.position, transform.position, out hit))
            {
            distance -= hit.distance;
            }
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            transform.rotation = rotation;
            transform.position = position;
            velocityX = Mathf.Lerp(velocityX, 0, Time.deltaTime * smoothTime);
            velocityY = Mathf.Lerp(velocityY, 0, Time.deltaTime * smoothTime);
        }
    }

    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        if (angle >= 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
