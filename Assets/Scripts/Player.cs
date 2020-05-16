using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    Vector3 movement;
    private void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        movement = new Vector3(horizontal, 0, vertical) * movementSpeed;
        transform.position += movement * Time.deltaTime;
        Vector3 pos = transform.position;
        Vector3 futurePos = transform.position + movement * Time.deltaTime;
        float angle = getAngle(pos, futurePos);
        Quaternion rot = transform.rotation;
        Quaternion futureRotation = Quaternion.Euler(0, angle, 0);
        Quaternion result = Quaternion.Slerp(rot, futureRotation, rotationSpeed * Time.deltaTime);
        if (Mathf.Abs(horizontal)>0.001f || Mathf.Abs(vertical)>0.001f)
        {
            transform.rotation = result;
        }
        
    }

    float getAngle(Vector3 from, Vector3 to)
    {
        float angle;
        Vector3 right = Vector3.right; //para que solo se mueva en x
        Vector3 dir = to - from;
        angle = Vector3.Angle(right, dir);
        Vector3 crossProduct = Vector3.Cross(right, dir);

        if (crossProduct.y<0)
        {
            angle = 360 - angle;
        }
        return angle;
    }
}
