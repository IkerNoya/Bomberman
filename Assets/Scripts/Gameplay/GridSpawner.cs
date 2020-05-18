
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject DestructibleWall;
    public List<GameObject> enemies = new List<GameObject>();
    public List<GameObject> walls = new List<GameObject>();
    int minX = -8;
    int maxX = 8;
    int minZ = -9;
    int maxZ = 9;
    public float gridY;
    public float gridSpacing = 1.0f;
    public Vector3 gridOrigin = Vector3.zero;
    public int wallAmmount;
    void Start()
    {
        SpawnInGrid();
    }
    void SpawnInGrid()
    {
        while(wallAmmount> 0)
        {
            float x = 0;
            float z = 0;
            if ((createPosX(ref x, minX, maxX) == true && createPosZ(ref z, minZ, maxZ) == true) || (createPosX(ref x, minX, maxX) == false && createPosZ(ref z, minZ, maxZ) == true))
            {
                Vector3 CreatedPos = new Vector3(x, enemies[0].transform.position.y, z); // para checkear si se crea en la misma posicion que los enemigos
                if (CreatedPos != enemies[0].transform.position)
                {
                    CreatedPos.y = 0;
                    CreatedPos = CreatedPos + gridOrigin;
                    GameObject go = Instantiate(DestructibleWall, CreatedPos, Quaternion.identity);
                    wallAmmount--;
                }
            }
        }
    }
    bool createPosX(ref float value, int min, int max)
    {
        value = Random.Range(min, max);
        if (value % 2 != 0 )
        {
            return false;
        }
        else 
        {
            return true;
        }
    }
    bool createPosZ(ref float value, int min, int max)
    {
        value = Random.Range(min, max);
        if (value % 2 == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
