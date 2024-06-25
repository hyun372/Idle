using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Right Side")]
    [SerializeField] private TMP_Text goldTxt;

    private void Update()
    {
        goldTxt.text = GameManager.Instance.money.ToString();
    }
}
