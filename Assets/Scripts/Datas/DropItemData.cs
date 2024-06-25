using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropItemData", menuName = "ScriptableObjects/DropItemData")]
public class DropItemData : ScriptableObject
{
    [SerializeField]
    private int id;
    public int ID => id;

    [SerializeField]
    private int price;
    public int Price => price;

    [SerializeField]
    private Sprite sprite;
    public Sprite Sprite => sprite;
}
