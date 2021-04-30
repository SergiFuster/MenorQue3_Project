using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    public int Money = 0;

    public void buyGun(int moneyAmount)
    {
        Money -= moneyAmount;
        Debug.Log("Current money: " + Money);
    }

    private void OnTriggerEnter(Collider other)
    {
        CurrencyController currency = other.GetComponent<CurrencyController>();
        if(currency != null)
        {
            Money += currency.value;
            currency.pickedUp();
            Debug.Log("Current money: " + Money);
        }

    }
}
