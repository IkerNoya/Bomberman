using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEditorInternal;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed;
    public LayerMask wall;
    public LayerMask dWall;
    public LayerMask ally;
    public LayerMask player;
    Vector3 movement;
    Vector3 direction;

    bool canMove = true;
    bool hitWall = false;
    public float range;


    int selection = 0;
    int currentSel = 10;
    Rigidbody enemy;
    RaycastHit hit;
    enum States
    {
        front, right, back, left, last
    }
    States states;
    private void Start()
    {
        enemy = GetComponent<Rigidbody>();
        direction = Vector3.forward;
        states = States.front;
    }
    private void Update()
    {
        if (!canMove)
        {
            return;
        }
        Debug.DrawRay(transform.position, transform.forward * 0.6f, Color.blue);
    }
    private void FixedUpdate()
    {
        if (!canMove)
        {
            return;
        }
        direction = transform.forward;
        if (canMove)
        {
            enemy.velocity += movement;
        }

        if (Physics.Raycast(transform.position, transform.forward, out hit, range, dWall))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            hitWall = true;
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit, range, wall))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            hitWall = true;
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit, range, ally))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            hitWall = true;
        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit, range, player))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.red);
            hitWall = true;

        }
        else if (Physics.Raycast(transform.position, transform.forward, out hit, range * 5))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);
        }
        if (hitWall)
        {
            enemy.velocity = Vector3.zero;
            canMove = false;
            StartCoroutine(stateSelector());
        }

        switch (states)
        {
            case States.front:
                transform.LookAt(transform.position + Vector3.forward);
                direction = transform.forward;
                movement = direction * movementSpeed * Time.deltaTime;
                break;
            case States.right:
                transform.LookAt(transform.position + Vector3.right);
                direction = transform.forward;
                movement = direction * movementSpeed * Time.deltaTime;
                break;
            case States.back:
                transform.LookAt(transform.position + Vector3.back);
                direction = transform.forward;
                movement = direction * movementSpeed * Time.deltaTime;
                break;
            case States.left:
                transform.LookAt(transform.position + Vector3.left);
                direction = transform.forward;
                movement = direction * movementSpeed * Time.deltaTime;
                break;
        }
    }
    IEnumerator stateSelector()
    {
        float timer = 0;

        while (timer <= 0.5f && selection == currentSel)
        {
            timer += Time.deltaTime;
            currentSel = Random.Range((int)States.front, (int)States.last);
            yield return null;
        }
        if (currentSel == (int)States.front)
        {
            states = States.front;
        }
        else if (currentSel == (int)States.right)
        {
            states = States.right;
        }
        else if (currentSel == (int)States.back)
        {
            states = States.back;
        }
        else if (currentSel == (int)States.left)
        {
            states = States.left;
        }
        selection = currentSel;
        canMove = true;
        hitWall = false;
        StopCoroutine(stateSelector());
        yield return null;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9)
        {
            enemy.velocity = Vector3.zero;
            enemy.angularVelocity = Vector3.zero;
        }

    }
}
