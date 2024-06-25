using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shop Item", menuName = "ScriptableObjects/ShopItemData")]
public class ShopItem : ScriptableObject
{
    public string Name = "Default";
    public string Description = "Description";
    public int Level;
    public int Price;
    public ObjectType Type;
    public Sprite Icon;
    public GameObject Prefab;
}

public enum ObjectType
{
    Crop,
    Animal,
    Mine
}