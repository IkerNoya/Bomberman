using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    Vector3 movement;
    bool canMove = false;
    public GameObject bomb;
    public bool isActive = false;
    private void Update()
    {

        if (Input.GetKey(KeyCode.Space) && !isActive)
        {
            Instantiate(bomb, CenterPosition(transform.position), Quaternion.identity);
            isActive = true;
        }
        
    }
    private void FixedUpdate()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Horizontal");
        Vector3 pos = transform.position;
        Vector3 futurePos = transform.position + movement * Time.deltaTime;
        float angle = getAngle(pos, futurePos);
        Quaternion rot = transform.rotation;
        Quaternion futureRotation = Quaternion.Euler(0, angle, 0);
        Quaternion result = Quaternion.Slerp(rot, futureRotation, rotationSpeed * Time.deltaTime);
        if (Mathf.Abs(horizontal) > 0.001f || Mathf.Abs(vertical) > 0.001f)
        {
            transform.rotation = result;
        }
        movement = new Vector3(horizontal, 0, vertical) * movementSpeed;
        GetComponent<Rigidbody>().velocity = movement * Time.deltaTime;
        GetComponent<Rigidbody>().AddForce(movement * movementSpeed);
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
    Vector3 CenterPosition(Vector3 position)
    {
        Vector3 newPosition = new Vector3(Mathf.RoundToInt(position.x), position.y, Mathf.RoundToInt(position.z));
        return newPosition;
    }
    private void OnCollisionEnter(Collision other)
    {
        int wallLayer = 8;
        if (other.collider.gameObject.layer == wallLayer)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
