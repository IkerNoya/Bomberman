using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    int desWallLayer = 9;
    private void Start()
    {
        Destroy(gameObject, 1f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "D_Wall")
        {
            Destroy(other.gameObject);
        }
    } 
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "D_Wall")
        {
            Destroy(other.gameObject);
        }
    }
}
