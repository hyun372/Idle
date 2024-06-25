using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "WorkData", menuName = "ScriptableObjects/WorkData")]
public class WorkData : ScriptableObject
{
    [SerializeField]
    private int id;
    public int ID => id;

    [SerializeField]
    private float hp;
    public float HP => hp;

    [SerializeField]
    private Sprite[] frames = new Sprite[4];
    public Sprite[] Frames => frames;

    //[SerializeField]
    //private GameObject dropItemPrefab;
    //public GameObject DropItemPrefab => dropItemPrefab;

    [SerializeField]
    private DropItemData dropItemData;
    public DropItemData DropItemData => dropItemData;
}
