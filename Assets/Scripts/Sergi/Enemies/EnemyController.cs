using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float health = 100f;
    public Transform target;
    public NavMeshAgent Agent;
    public float distanceToDetect;
    public float distanceToAttack;
    private bool targetDetected = false;
    private float distance;
    public float attackRate;
    private float nextTimeToAttack = 0f;
    public Animator anim;
    private bool dead = false;
    public Transform attackPoint;
    public float damageAttack;
    public Transform bleedPoint;
    public ParticleSystem bleed;

    private void Start()
    {
        setRigidbodiesState(true);
        setCollidersState(false);
    }
    private void Update()
    {
        if (dead) return;

        distance = (transform.position - target.position).magnitude;

        if (distance < distanceToDetect) targetDetected = true; //Check if enemy have detected player


        //Check if is close enough and if attack rate lets attack
        if (targetDetected)
        {
            if (distance < distanceToAttack)
            {
                if (Time.time >= nextTimeToAttack)
                {
                    nextTimeToAttack = Time.time + 1f / attackRate;
                    StartCoroutine(Attack());
                }
            }
            else
            {
                Agent.SetDestination(target.position);
                anim.SetFloat("speed", Agent.speed);
                Agent.isStopped = false;
            }
        }

    }

    public void damageEnemy(float damage)
    {
        health -= damage;


        bleed.Play(bleedPoint);
        
        if (health <= 0)
        {
            Die();
        }
        else hurted();
    }

    void Die()
    {

        Destroy(gameObject, 3f);
        GetComponent<Animator>().enabled = false;
        setRigidbodiesState(false);
        setCollidersState(true);
        Agent.isStopped = true;
        dead = true;


    }

    void hurted()
    {
        Debug.Log(gameObject.name + " current health: " + health);
        Agent.isStopped = true;
        //anim.SetTrigger("damage");
    }

    IEnumerator Attack()
    {
        anim.SetFloat("speed", 0f);
        anim.SetTrigger("attack");
        Agent.isStopped = true;
        yield return new WaitForSeconds(1f);
        Collider[] colliders = Physics.OverlapSphere(attackPoint.position, 50f);
        foreach (Collider closeObjects in colliders)
        {
            PlayerHealthManager player = closeObjects.GetComponent<PlayerHealthManager>();
            if (player != null)
            {
                player.damaged(damageAttack);
            }
        }
    }

    void setRigidbodiesState(bool state)
    {
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;

    }

    void setCollidersState(bool state)
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        GetComponent<Collider>().enabled = !state;

    }

    

}
