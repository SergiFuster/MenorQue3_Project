using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public PlayerMovement movement;
    private ProjectileGun Gun;
    public PlayerHealthManager health;

    public void callerPowerUp(PowerUpController.type PowerUp, float multiplier, float duration)
    {
        StartCoroutine(initializePowerUp(PowerUp, multiplier, duration));
    }

    public IEnumerator initializePowerUp(PowerUpController.type PowerUp, float multiplier, float duration)
    {
        if(PowerUp.ToString() == "speed")
        {
            movement.movementSpeed *= multiplier;
            yield return new WaitForSeconds(duration);
            movement.movementSpeed /= multiplier;
        }
        else if(PowerUp.ToString() == "health")
        {
            health.takeHealth(multiplier);
            yield return new WaitForSeconds(0f);
        }
        else if(PowerUp.ToString() == "fireRate")
        {
            Gun = gameObject.transform.Find("WeaponContainer").GetChild(0).GetComponent<ProjectileGun>();
            Gun.fireRate *= multiplier;
            yield return new WaitForSeconds(duration);
            Gun.fireRate /= multiplier;

        }
    }
}
