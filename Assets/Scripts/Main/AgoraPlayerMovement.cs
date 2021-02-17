using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgoraPlayerMovement : MonoBehaviour
{
    float horizontal;
    float vertical;

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontal, 0f, vertical)*0.1f);
    }
}
