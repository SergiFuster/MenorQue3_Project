using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public float moveSpeed = 3.5f;
    public float hpNow;
    private float crono;
    public int nBombs = 3;
    public Text nBombsText;
    public NavMeshAgent enemy;
    public Transform player;


    NavMeshAgent navMeshAgent;
    Animator m_Animator;
    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    //Quaternion m_Rotation = Quaternion.identity;
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

        PlayerGetHit();
        Debug.DrawRay(transform.position, transform.forward, Color.red);
    }

    void FixedUpdate()
    {
        
        m_Movement.Normalize();

    }


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
        if(nBombs > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            { //Presiono el espacio
                Instantiate(bomb, new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), Mathf.Round(transform.position.z)) + bomb.transform.position, Quaternion.AngleAxis(bomb.transform.rotation.eulerAngles.x, new Vector3(1, 0, 0)));
                nBombs -= 1;
                nBombsText.text = "" + nBombs;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bomb")
        {
            hpNow -= 20;
        }
    }


    void PlayerGetHit()
    {

        crono += 1f * Time.deltaTime;

        if(Vector3.Distance(player.position, enemy.transform.position) < 1f)
        {
            if (crono >= 2)
            {
                hpNow -= 20;
                crono = 0f;
            }
        }
        //Game Over
        
        //Debug.Log(Vector3.Distance(player.position, enemy.transform.position));
    }
}
