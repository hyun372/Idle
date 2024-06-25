using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if(hit.collider!=null )
            {
                if (hit.collider.CompareTag(TagAndLayers.TagName.Work))
                {
                    Work work = hit.collider.GetComponent<Work>();
                    if (work != null) { work.OnClicked(); }
                }

                if(hit.collider.CompareTag(TagAndLayers.TagName.DropItem))
                {
                    DropItem dropItem = hit.collider.GetComponent<DropItem>();
                    if (dropItem != null) { dropItem.OnClicked(); }
                }
            }
            
        }
    }
}
