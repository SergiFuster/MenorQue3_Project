using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Quaternion newDirection;
    Rigidbody m_rigidbody;
    public float m_bulletVelocity;
    Vector3 m_movement;
    Quaternion m_rotation = Quaternion.identity;
        

    private void FixedUpdate()
    {
        newDirection = transform.rotation * Quaternion.Euler()
        m_movement = transform.forward * m_bulletVelocity;
        m_rigidbody.MovePosition(m_rigidbody.position + m_movement);
    }
}
