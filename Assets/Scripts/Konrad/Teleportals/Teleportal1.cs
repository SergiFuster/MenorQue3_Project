using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleportal1 : MonoBehaviour
{
    public Transform teleport;
    public GameObject player;
    private bool doIt = false;
    private NavMeshAgent navAgent;

    private void Start()
    {
        navAgent = player.GetComponent<NavMeshAgent>();
    }

    void Update() {
        Teleportation();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Jugador")
        {
            doIt = true;
            Debug.Log("Trigger entered");

        }
    }

    public void Teleportation()
    {
        if (doIt)
        {
            doIt = false;
            navAgent.enabled = false;
            player.transform.position = teleport.position;
            navAgent.enabled = true;
        }
    }
}
