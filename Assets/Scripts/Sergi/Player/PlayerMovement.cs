using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 6f;
    Rigidbody rb;
    public static Vector3 mousePosition;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Debug.Log(rb.velocity);
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
        Physics.Raycast(mouseRay.origin, mouseRay.direction, out RaycastHit hit);
        Debug.DrawRay(mouseRay.origin, mouseRay.direction * 200f, Color.red);

        if (hit.collider != null)
        {
            mousePosition = hit.point;
            if (hit.collider.gameObject.name == "FieldView")
                transform.LookAt(hit.point);
        }
        
    }
}
