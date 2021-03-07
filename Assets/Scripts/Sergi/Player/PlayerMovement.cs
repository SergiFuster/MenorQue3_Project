using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 6f;
    CharacterController controller;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void FixedUpdate()
    {
        //Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.SimpleMove(direction * movementSpeed);
        }

        //Orientation
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(mouseRay.origin, mouseRay.direction, out RaycastHit hit);
        Debug.DrawRay(mouseRay.origin, mouseRay.direction * 200f, Color.red);

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.name == "FieldView")
                transform.LookAt(hit.point);
        }
        
    }
}
