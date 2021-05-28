using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gun_Movement : MonoBehaviour
{    
    private float aggro = 25f;
    //private NavMeshAgent navmesh;
    private Rigidbody rig;
    private float last_mag;
    private int shot_count;
    private float last_shot;
    private int speed = 1;
    private bool isInRange;
    
    public Animator anim;

    public GameObject bullet;
    public float bulletSpeed = 125f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //navmesh = GetComponent<NavMeshAgent>();
        rig = GetComponent<Rigidbody>();
        last_mag = 0f;
        shot_count = 0;
        last_shot = 0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerControl.vida > 0)
        {
            transform.LookAt(player.position);
            Reposition();
            anim.SetBool("inRange", isInRange);
        }
        else
            anim.SetBool("inRange", false);
        
        //navmesh.SetDestination(player.position);
    }

    public void Reposition()
    {
        if(Vector3.Distance(player.position, transform.position) < aggro)
        {
            if (Vector3.Distance(player.position, transform.position) < aggro - 17) //Retreat
            {
                Vector3 direction = transform.position - player.position;
                transform.position += direction * speed * Time.deltaTime;
                isInRange = true;
                //rig.AddForce(direction * 5f);
            }
            else isInRange = false;

            Shoot();
        }

    }

    public void Shoot()
    {
        if (Time.time - last_mag > 3)
        {
            if (shot_count < 8)
            {
                if (Time.time - last_shot > 0.25)
                {
                    GameObject bulletInst = Instantiate(bullet, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
                    Transform bulletInstTransform = bulletInst.GetComponent<Transform>();
                    bulletInstTransform.LookAt(player.position);
                    Rigidbody bulletInstRigidbody = bulletInst.GetComponent<Rigidbody>();
                    bulletInstRigidbody.AddForce(bulletInstTransform.forward * bulletSpeed);
                    Destroy(bulletInst, 5f);

                    shot_count++;
                    last_shot = Time.time;
                }
            }
            else
            {
                shot_count = 0;
                last_mag = Time.time;
            }
        }
    }

}
