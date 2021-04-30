using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public float multiplier;
    public float duration;
    public enum type
    {
        speed,
        health,
        fireRate
    }
    public type PowerUp;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            //llama a la función que se ocupa de inicia el boost
            other.GetComponent<PowerUpManager>().callerPowerUp(PowerUp, multiplier, duration);
            Destroy(gameObject);
        }
    }
}
