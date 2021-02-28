using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    public float movementSpeed = 6f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * movementSpeed * Time.deltaTime);
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
