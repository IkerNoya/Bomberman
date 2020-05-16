using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject DestructibleWall;
    public float gridX;
    public float gridY;
    public float gridSpacing = 1.0f;
    public Vector3 gridOrigin = Vector3.zero;
    public int wallAmmount;
    void Update()
    {
        SpawnInGrid();
    }
    void SpawnInGrid()
    {
        if (wallAmmount > 0)
        {
            float x = 0;
            float z = 0;
            if ((createPosX(ref x, -8, 8) == true && createPosZ(ref z, -9,9)==true) || (createPosX(ref x, -8,8) == false && createPosZ(ref z, -9, 9) == true))
            {
                Vector3 CreatedPos = new Vector3(x, 0, z) + gridOrigin;
                Instantiate(DestructibleWall, CreatedPos, Quaternion.identity);
                wallAmmount--;
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
