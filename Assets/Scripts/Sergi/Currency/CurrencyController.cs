using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    public int value;
    public void pickedUp()
    {
        //display sound
        //display effect
        Destroy(gameObject);
    }
}
