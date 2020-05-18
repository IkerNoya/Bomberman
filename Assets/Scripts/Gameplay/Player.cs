
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed;
    Vector3 movement;
    public GameObject bomb;
    public bool isActive = false;
    public int hp = 2;
    int explosionLayer = 12;
    int enemyLayer = 10;
    public Camera mainCamera;
    public bool Dead = false;
    bool win = false;
    public Vector3 cameraOffset;
    public Vector3 cameraRotation;

    float endTimer = 0;
    int timerLimit = 3;
    public bool end = false;


    public delegate void Die();
    public static event Die die;
    private void Update()
    {
        if (!Dead)
        {
            if (Input.GetKey(KeyCode.Space) && !isActive)
            {
                GameObject go = Instantiate(bomb, CenterPosition(transform.position), Quaternion.identity); 

                isActive = true;
            }

        }
        if (Dead)
        {
            endTimer += Time.deltaTime;
            if (endTimer>=timerLimit)
            {
                end = true;
            }
        }
        if (die != null && end)
        {
            die();
        }

    }
    private void FixedUpdate()
    {
        if (!Dead)
        {
            mainCamera.transform.position = transform.position + cameraOffset;
            mainCamera.transform.eulerAngles = cameraRotation;
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
    }
    public float getAngle(Vector3 from, Vector3 to)
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
        if (other.gameObject.layer == enemyLayer)
        {
            hp--;
            if (hp<=0)
            {
                Dead = true;

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == explosionLayer)
        {
            hp--;
            if (hp <= 0)
            {
                Dead = true;
            }
        }
    }
}
