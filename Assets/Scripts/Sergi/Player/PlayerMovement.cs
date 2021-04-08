using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 6f;
    Rigidbody rb;
    public static Vector3 mousePosition;
    Transform tm;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        tm = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        //Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            transform.position += direction * movementSpeed;
        }

        //Orientation
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(mouseRay, out RaycastHit hit);

        mousePosition = hit.point;

        Vector3 orientation = mousePosition;
        orientation.y = tm.position.y;
        
        transform.LookAt(orientation);
        
    }
}
