using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Melee_Movement : MonoBehaviour
{
    public Transform player;
    public float aggro = 20f;
    
    public Animator anim;

    private bool isAggroed;
    private NavMeshAgent navmesh;


    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();
        isAggroed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerControl.vida > 0) { 
            transform.LookAt(player.position);
            if (Vector3.Distance(player.position, transform.position) < aggro)
            {
                if (!isAggroed)
                    isAggroed = true;
                navmesh.SetDestination(player.position);
            }
            else if (isAggroed)
                isAggroed = false;

            anim.SetBool("isAggroed", isAggroed);
        }
        else
            anim.SetBool("isAggroed", false);
    }

    void OnTriggerEnter(Collider other)
    {
        
    }
}
