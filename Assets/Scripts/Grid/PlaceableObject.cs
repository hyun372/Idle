using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public bool isPlaced { get; private set; }
    private Vector3 origin;

    public BoundsInt area;

    public bool CanBePlaced()
    {
        Vector3Int positionInt = BuildingSystem.Instance.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        if(BuildingSystem.Instance.CanTakeArea(areaTemp))
        {
            return true;
        }

        return false;
    }

    public void Place()
    {
        Vector3Int positionInt = BuildingSystem.Instance.gridLayout.LocalToCell(transform.position);
        BoundsInt areaTemp = area;
        areaTemp.position = positionInt;

        isPlaced = true;

        BuildingSystem.Instance.TakeArea(areaTemp);
    }

    public void CheckPlacement()
    {
        if(CanBePlaced())
        {
            Place();
            origin = transform.position;
        }
        else
        {
            Destroy(transform.gameObject);
        }
    }
}
