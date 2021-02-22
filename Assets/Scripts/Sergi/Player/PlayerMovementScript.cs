using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour {

    public float moveSpeed;
    public float turnSpeed;


    private Vector3 moveDirection;


    void Update()
    {
        moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * (Input.GetAxis("Horizontal") * turnSpeed));
    }
}
