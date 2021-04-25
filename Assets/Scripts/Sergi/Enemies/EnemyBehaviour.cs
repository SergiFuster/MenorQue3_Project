using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent Agent;
    public bool targetDetected = false;
    public float distanceToDetect;
    public float distanceToAttack;
    private float Distance;
    public float attackRate;
    private float nextTimeToAttack = 0f;

    private void Update()
    {
        Distance = (transform.position - target.position).magnitude;

        if (Distance > distanceToDetect) return; //Check if enemy have detected player


        //Check if is close enough and if attack rate lets attack
        if (Distance < distanceToAttack)
        {
            if (Time.time >= nextTimeToAttack)
            {
                nextTimeToAttack = Time.time + 1f / attackRate;
                Attack();
            }
        }
        else Agent.SetDestination(target.position);
    }

    public void Attack()
    {
        Debug.Log("Attack!");
    }

}
