using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent Agent;
    public float distanceToDetect;
    public float distanceToAttack;
    private bool targetDetected = false;
    private float distance;
    public float attackRate;
    private float nextTimeToAttack = 0f;
    public Animator anim;

    private void Update()
    {
        distance = (transform.position - target.position).magnitude;

        if (distance < distanceToDetect) targetDetected = true; //Check if enemy have detected player


        //Check if is close enough and if attack rate lets attack
        if (targetDetected)
        {
            if(distance < distanceToAttack)
            {
                if (Time.time >= nextTimeToAttack)
                {
                    nextTimeToAttack = Time.time + 1f / attackRate;
                    Attack();
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

    public void Attack()
    {
        anim.SetFloat("speed", 0f);
        anim.SetTrigger("attack");
        Agent.isStopped = true;
    }

}
