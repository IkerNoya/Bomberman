
using UnityEngine;

public class Explosion : MonoBehaviour
{
    int desWallLayer = 9;
    int enemyLayer = 10;
    public delegate void AddScoreBox();
    public static event AddScoreBox addScoreBox;
    public delegate void AddScoreEnemy();
    public static event AddScoreEnemy addScoreEnemy;
    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "D_Wall" )
        {
            Destroy(other.gameObject);
            if (addScoreBox!=null)
            {
                addScoreBox();
            }
        }
        if (other.gameObject.layer == enemyLayer)
        {
            Destroy(other.gameObject);
            if (addScoreEnemy != null)
            {
                addScoreEnemy();
            }
        }
    } 
}
