using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public float Health = 100;
    public HealthBar healthBar;
    public PauseMenu pauseMenuUI;

    private void Start()
    {
        healthBar.setMaxHealth(Health);
    }
    public void damaged(float amountDamage)
    {
        Health -= amountDamage;
        healthBar.setHealth(Health);

        if(Health <= 0)
        {
            Die();
        }
        else
        {
            hurted();
        }
    }

    void hurted()
    {
        Debug.Log("YOU WAS DAMAGED");
    }

    void Die()
    {
        pauseMenuUI.DeadMenu();
    }

    public void takeHealth(float amountHeal)
    {
        if(Health + amountHeal <= 100f)
        {
            Health += amountHeal;
        }
        else
        {
            Health = 100f;
        }

        healthBar.setHealth(Health);
    }
}
