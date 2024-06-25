using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public bool isBuilding = false;

    private void Update()
    {
        
    }

    public void Build(GameObject workPrefab)
    {
        Instantiate(workPrefab, transform.position, Quaternion.identity);
    }
}
