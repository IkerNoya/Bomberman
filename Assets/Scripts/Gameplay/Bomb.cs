
using UnityEngine;

public class Bomb : MonoBehaviour
{
    float timer = 3;
    GameObject player;
    int playerLayer = 11;
    public GameObject explosion;
    private void Start()
    {
        player = GameObject.Find("Player");
        GetComponent<SphereCollider>().isTrigger = true;
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
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == playerLayer)
        {
            GetComponent<SphereCollider>().isTrigger = false;
        }
    }
}
