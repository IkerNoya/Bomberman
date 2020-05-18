using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float timer = 3;
    GameObject player;
    public GameObject explosion;
    private void Start()
    {
        player = GameObject.Find("Player");
        Destroy(gameObject, 3.1f);
    }
    void Update()
    {
        if (player.GetComponent<Player>().isActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                GameObject clone1 = (GameObject)Instantiate(explosion, transform.position + Vector3.right, Quaternion.identity);
                GameObject clone2 = (GameObject)Instantiate(explosion, transform.position + Vector3.forward, Quaternion.identity);
                GameObject clone3 = (GameObject)Instantiate(explosion, transform.position + Vector3.left, Quaternion.identity);
                GameObject clone4 = (GameObject)Instantiate(explosion, transform.position + Vector3.back, Quaternion.identity);
                player.GetComponent<Player>().isActive = false;
                Destroy(clone1, 0.8f);
                Destroy(clone2, 0.8f);
                Destroy(clone3, 0.8f);
                Destroy(clone4, 0.8f);
            }
        }
    }
}
