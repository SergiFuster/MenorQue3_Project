using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public float moveSpeed = 3.5f;

    NavMeshAgent navMeshAgent;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        Move();
        InvokeBombs();
        Debug.DrawRay(transform.position, transform.forward, Color.red);
    }

    void FixedUpdate()
    {
        
        m_Movement.Normalize();



        /*
       
        

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward); **/

    }

    /*private void OnAnimatorMove()
    {
        Vector3 v = m_Rigidbody.position + m_Movement * Time.deltaTime * 3.5f;
        print(m_Movement);
        print(v);
        m_Rigidbody.MovePosition(v);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
    */

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        m_Movement = new Vector3(horizontal, 0f, vertical);

        Vector3 v = m_Movement * Time.deltaTime * moveSpeed;    //A donde quiero ir
        m_Rigidbody.MovePosition(m_Rigidbody.position + v);     //Me muevo de donde estoy a donde quiero ir
        transform.LookAt(m_Rigidbody.position + m_Movement);    //Me giro dependiendo de donde esta mi nuevo destino

        m_Animator.SetBool("Run Forward", m_Movement != Vector3.zero);

    }
    void InvokeBombs()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Presiono el espacio
            Instantiate(bomb, transform.position + bomb.transform.position, Quaternion.identity);
    }
}
