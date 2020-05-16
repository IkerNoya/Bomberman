using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float timer = 3;
    GameObject player;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (player.GetComponent<Player>().isActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Destroy(gameObject);
                player.GetComponent<Player>().isActive = false;
            }
        }
    }
}
