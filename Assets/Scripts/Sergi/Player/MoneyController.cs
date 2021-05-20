using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public static float Money = 0;
    public MoneyUI moneyText;

    public void buyGun(int moneyAmount)
    {
        moneyText.updateMoney(-moneyAmount); //Update the UI money text
        Debug.Log("Current money: " + Money);
    }

    private void OnTriggerEnter(Collider other)
    {
        CurrencyController currency = other.GetComponent<CurrencyController>();
        if(currency != null)
        {
            currency.pickedUp();
            moneyText.updateMoney(currency.value); //Update the UI money text
            Debug.Log("Current money: " + Money);
        }

    }
}
