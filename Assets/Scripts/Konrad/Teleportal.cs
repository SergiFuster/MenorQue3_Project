using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleportal : MonoBehaviour
{
    public Transform teleport;
    //public GameObject player;
    //private bool doIt = false;
    private NavMeshAgent navAgent;

    private void Start()
    {
        //navAgent = player.GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Trigger entered");
            Teleportation(col.gameObject);

        }
    }

    public void Teleportation(GameObject player)
    {
        navAgent = player.GetComponent<NavMeshAgent>();
        navAgent.enabled = false;
        player.transform.position = teleport.position;
        navAgent.enabled = true;
    }
}
