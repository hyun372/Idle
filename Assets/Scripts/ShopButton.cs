using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    public ShopItem shopItemData;

    public Image icon;
    public TMP_Text priceTxt;

    private void Update()
    {
        //icon.sprite = shopItemData.Icon;
        priceTxt.text = shopItemData.Price.ToString();
    }

    public void OnClick()
    {
        if (GameManager.Instance.money >= shopItemData.Price)
        {
            GameManager.Instance.iconDrag.isDrag = true;
            GameManager.Instance.iconDrag.currentItem = shopItemData;
            GameManager.Instance.money -= shopItemData.Price;
        }
    }
}
