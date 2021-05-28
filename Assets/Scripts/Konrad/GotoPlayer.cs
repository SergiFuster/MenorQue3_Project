using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotoPlayer : MonoBehaviour
{
    [SerializeField]
    public Transform player;

    void Update()
    {
        if(PlayerControl.vida>0)
            transform.position = player.position;
    }
}
