using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [HideInInspector] public int id;
    [HideInInspector] public int price;
    [HideInInspector]public int stack = 1;

    private Vector2 direction;
    private float speed = 5f;

    public bool isDone = false;
    private float moveTime = .5f;
    private float timer;

    public SpriteRenderer spriter;

    [SerializeField] private TMP_Text stackTxt;

    private void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        stack = 1;
    }

    private void Start()
    {
        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        direction.Normalize();
    }

    private void Update()
    {
        SpawnMoving();

        if (stack > 1) stackTxt.text = stack.ToString();

        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            isDone = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagAndLayers.TagName.DropItem))
        {
            DropItem dropItem = collision.GetComponent<DropItem>();

            if (dropItem != null)
            {
                if (dropItem.id == id && isDone == true && dropItem.stack <= 99)
                {
                    stack += dropItem.stack;
                    Destroy(dropItem.gameObject);
                }
            }
        }
    }

    public void SetData(int id, int price, Sprite sprite)
    {
        this.id = id;
        this.price = price;
        spriter.sprite = sprite;
    }

    private void SpawnMoving()
    {
        if (!isDone)
        {
            if(timer >= moveTime/3) { speed /= 2; }
            Vector2 pos = transform.position;
            pos += direction * speed * Time.deltaTime;
            transform.position = pos;
        }
    }

    public void OnClicked()
    {
        GameManager.Instance.money += price * stack;
        Destroy(gameObject);
    }
}
