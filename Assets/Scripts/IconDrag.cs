using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconDrag : MonoBehaviour
{
    public ShopItem currentItem;
    public bool isDrag = false;

    private SpriteRenderer spriter;

    private void Awake()
    {
        spriter = GetComponent<SpriteRenderer>();
        spriter.enabled = false;
    }

    private void LateUpdate()
    {
        if (isDrag)
        {
            Click();

            spriter.enabled = true;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            spriter.sprite = currentItem.Icon;
            transform.position = mousePos;
        }
        else
        {
            spriter.enabled = false;
        }
    }

    private void Click()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag(TagAndLayers.TagName.Tile))
                {
                    hit.transform.gameObject.GetComponent<Tile>().Build(currentItem.Prefab);
                    isDrag = false;
                }
            }
        }
    }
}
