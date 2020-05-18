using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Des_Wall : MonoBehaviour
{
    int explosionLayer = 12;
    public int hp = 1;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == explosionLayer)
        {
            hp--;
            if (hp<=0)
            {
                Die();
            }
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
