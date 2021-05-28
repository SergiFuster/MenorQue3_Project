using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class EnemyDavid_Script : MonoBehaviour
{
    private float timer;
    public float moveSpeed = 20f;
    public float turnSpeed = 3.5f;
    public float enemyHp = 100f;
    public float enemyHpNow = 100f;
    public bool attack;

    Animator m_EnemyAnimator;
    public NavMeshAgent enemy;
    public Transform player;



    /*public void Enemy_behaviour()
    {
        crono += 1 * Time.deltaTime;
        state = Random.Range(0, 2);
        crono = 0;

        var lookPos = player.position - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3);

        m_EnemyAnimator.SetBool("Idle", false);

        m_EnemyAnimator.SetBool("Run Forward", true);
        transform.Translate(Vector3.forward * 2 * Time.deltaTime);

    }*/


    // Start is called before the first frame update
    void Start()
    {
        m_EnemyAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();

    }

    void MoveEnemy()
    {
        if (Vector3.Distance(transform.position, player.position)> 1 && !attack)
        {
            var lookPos = player.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 3.5f);

            m_EnemyAnimator.SetBool("Run Forward", true);
            transform.Translate(Vector3.forward * 3.5f * Time.deltaTime);

            m_EnemyAnimator.SetBool("Attack", false);

            

        }
        else
        {
            EnemyAttack();         
            Final_Anima();

        }
        
    }

    public void Final_Anima()
    {

        timer += 1f * Time.deltaTime;
        if (timer >= 2)
        {
            m_EnemyAnimator.SetBool("Attack", false);
            attack = false;
            timer = 0;
            
        }
        
    }

    

    void EnemyDie()
    {
        if(enemyHpNow <= 0)
        {
            Debug.Log("He muerto");
            

        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Box")
        { 

            EnemyAttack();
            Final_Anima();
            Destroy(other.gameObject);
 
        }

        if(other.tag == "Bomb")
        {
            if(enemyHpNow <= 0)
            {
                EnemyDie();
            }
            else
            {
                enemyHpNow -= 20;
            }
        }
       
    }

    void EnemyAttack()
    {

        //Si el enemigo se encuentra a una distancia respecto del personaje lanza un ataque y al realizar el ataque descansa de este
        m_EnemyAnimator.SetBool("Run Forward", false);
        m_EnemyAnimator.SetBool("Attack", true);
        attack = true;
    }
}
