using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody player;
    private Vector3 move;
    private int speed = 13;

    public Transform pointer;
    public bool isMoving;
    public Animator anim;
    

    void Start()
    {
        player = GetComponent<Rigidbody>();
        isMoving = false;
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
        Look();
        anim.SetBool("IsMoving", isMoving);
    }

    public void Move()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            player.transform.position += move * speed * Time.deltaTime;
            isMoving = true;
        }
        else
            isMoving = false;
    }

    public void Look()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.LookAt(new Vector3(pointer.position.x, transform.position.y, pointer.position.z));
        }
        else if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!=0)
            transform.LookAt(transform.position + new Vector3(move.x, 0, move.z));
    }
}
