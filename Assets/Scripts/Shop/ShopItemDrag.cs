using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopItemDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Image image;

    private Vector3 originPos;
    private bool isDrag;

    private void Awake()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        image = GetComponent<Image>();
        originPos = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
        canvasGroup.blocksRaycasts = false;
        image.maskable = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        canvasGroup.blocksRaycasts = true;
        image.maskable = true;
        rectTransform.anchoredPosition = originPos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    private void OnEnable()
    {
        isDrag = false;
        canvasGroup.blocksRaycasts = true;
        image.maskable = true;
        rectTransform.anchoredPosition = originPos;

        Color c = image.color;
        c.a = 1;
        image.color = c;
    }
}
