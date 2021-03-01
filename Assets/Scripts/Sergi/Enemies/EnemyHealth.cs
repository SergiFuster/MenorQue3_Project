using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    public void damageEnemy(int damage)
    {
        health -= damage;

        
        if (health <= 0)
        {
            Die();
        }
        else hurted();
    }

    void Die()
    {
        Debug.Log(gameObject.name + " has died!");
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void hurted()
    {
        Debug.Log(gameObject.name + " current health: " + health);
    }
}
