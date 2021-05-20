using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyController : MonoBehaviour
{
    public int value;

    private void Start()
    {
        transform.parent = GameObject.Find("Currencies").transform;
    }
    public void pickedUp()
    {
        //display sound
        //display effect
        Destroy(gameObject);
    }
}
