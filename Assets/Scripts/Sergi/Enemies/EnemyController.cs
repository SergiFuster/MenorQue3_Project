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
    public bool targetDetected = true;
    private float distance;
    public float attackRate;
    private float nextTimeToAttack = 0f;
    public Animator anim;
    private bool dead = false;
    public Transform attackPoint;
    public float damageAttack;
    public HealthBar healthBar;

    public GameObject goldToken;
    public GameObject diamondToken;
    public GameObject magmaToken;

    const int goldTokenProb = 50;
    const int diamondTokenProb = 10;
    const int magmaTokenProb = 5;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
        setRigidbodiesState(true);
        setCollidersState(false);
        healthBar.setMaxHealth(health);
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

        healthBar.setHealth(health);
        
        if (health <= 0)
        {
            Die();
        }
        else hurted();
    }

    void Die()
    {
        Rigidbody zombieRB = this.GetComponent<Rigidbody>();
        //Random token spawner
        int random;
        random = Random.Range(0, 100);

        if (random <= goldTokenProb)
        {
            if (random <= diamondTokenProb)
            {
                if (random <= magmaTokenProb)
                {
                    GameObject currencie = Instantiate(magmaToken, transform.position + new Vector3(0, 10, 0), Quaternion.identity);
                    Rigidbody rb = currencie.GetComponent<Rigidbody>();
                    rb.AddTorque(new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90)), ForceMode.Impulse);
                }
                else
                {
                    GameObject currencie = Instantiate(diamondToken, transform.position + new Vector3(0, 10, 0), Quaternion.identity);
                    Rigidbody rb = currencie.GetComponent<Rigidbody>();
                    rb.AddTorque(new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90)), ForceMode.Impulse);


                }
            }
            else
            {
                GameObject currencie = Instantiate(goldToken, transform.position + new Vector3(0, 10, 0), Quaternion.identity);
                Rigidbody rb = currencie.GetComponent<Rigidbody>();
                rb.AddTorque(new Vector3(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90)), ForceMode.Impulse);
            }

        }


        //Destroy enemy
        Destroy(gameObject, 3f);
        GetComponent<Animator>().enabled = false;
        setRigidbodiesState(false);
        setCollidersState(true);
        Agent.isStopped = true;
        dead = true;
        GameObject.Find("RoundManager").GetComponent<RoundController>().enemyKilled();

        


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
