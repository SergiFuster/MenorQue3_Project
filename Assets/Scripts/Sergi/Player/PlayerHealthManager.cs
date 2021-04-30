using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{

    public float Health = 100;

    public void damaged(float amountDamage)
    {
        Health -= amountDamage;

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
        Debug.Log("YOU HAVE DIED");
    }
}
