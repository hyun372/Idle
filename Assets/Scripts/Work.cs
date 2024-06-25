using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Work : MonoBehaviour
{
    public WorkData workData;

    private float hp;
    private float maxHp;
    private int phase = Mathf.Clamp(0, 0, 3);
    private Sprite[] sprites = new Sprite[4];
    public GameObject dropItemPrefab;

    private SpriteRenderer spriter;

    private HitFlash hitFlash;


    private void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        hitFlash = GetComponent<HitFlash>();

        maxHp = workData.HP;
        sprites = workData.Frames;
    }

    private void Start()
    {
        Init();
    }

    private void Update()
    {
        PhaseControl();
    }

    public void OnClicked()
    {
        hp--;
        hitFlash.CallHitFlash();
        if (hp <= 0)
        {
            if (dropItemPrefab != null) { Drop(); }
            hp = maxHp;
        }
    }
    private void Init()
    {
        hp = maxHp;
        phase = 0;
    }

    private void PhaseControl()
    {
        if (hp >= maxHp * .8) { phase = 0; }
        else if (hp >= maxHp * .6) { phase = 1; }
        else if (hp >= maxHp * .4) { phase = 2; }
        else if (hp >= maxHp * .2) { phase = 3; }

        spriter.sprite = sprites[phase];
    }

    public void Drop()
    {
        // 프리팹 인스턴스화
        GameObject dropItemInstance = Instantiate(dropItemPrefab, new Vector2(transform.position.x, transform.position.y - spriter.size.y / 4), Quaternion.identity);

        // 인스턴스에 대한 데이터 설정
        DropItem dropItemComponent = dropItemInstance.GetComponent<DropItem>();
        if (dropItemComponent != null)
        {
            dropItemComponent.SetData(workData.DropItemData.ID, workData.DropItemData.Price, workData.DropItemData.Sprite);
        }
        else
        {
            Debug.LogError("DropItem component not found on instantiated object.");
        }
    }
}
