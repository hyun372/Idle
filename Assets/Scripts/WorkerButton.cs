using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorkerButton : MonoBehaviour
{
    public GameObject workerPrefab;

    public TMP_Text workerPriceTxt;

    private void Update()
    {
        workerPriceTxt.text = GameManager.Instance.workerPrice.ToString();
    }

    public void ButtonDown()
    {
        if (workerPrefab != null && GameManager.Instance.money >= GameManager.Instance.workerPrice)
        {
            Instantiate(workerPrefab, new Vector2(-3, 0), Quaternion.identity);
            GameManager.Instance.money -= GameManager.Instance.workerPrice;
            GameManager.Instance.workerPrice = GameManager.Instance.workerPrice * 2;
        }
    }
}
