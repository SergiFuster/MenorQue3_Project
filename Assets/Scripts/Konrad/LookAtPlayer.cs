using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Vector3 _offset;
    private float smoothFactor = 1f;

    [SerializeField]
    public Transform player;

    void Start()
    {
        _offset = transform.position - player.position;    
    }

    void LateUpdate()
    {
        if (PlayerControl.vida > 0)
        {
            Vector3 newPosition = player.position + _offset;

            transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
