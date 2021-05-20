using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class MoneyUI : MonoBehaviour
{
    public TextMeshProUGUI currentMoneyText;


    private void Start()
    {
        currentMoneyText.text = MoneyController.Money.ToString() + " $";
    }

    public void updateMoney(float money)
    {
        StartCoroutine(moneyAnimation(money));
    }

    IEnumerator moneyAnimation(float money)
    {
        float aux = MoneyController.Money;
        MoneyController.Money += money;

        while (aux != MoneyController.Money)
        {
            aux += money / 10;
            currentMoneyText.text = aux.ToString() + " $";
            yield return new WaitForSeconds(0.0001f);
        }
    }
}
