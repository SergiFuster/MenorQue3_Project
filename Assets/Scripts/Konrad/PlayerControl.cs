using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody player;
    private Vector3 move;
    private int speed = 13;
    private float last_shot;
    private int cristales;

    public Transform pointer;
    public bool isMoving;
    public Animator anim;

    public GameObject bullet;
    public float bulletSpeed;

    public Text text;

    public static int vida;


    void Start()
    {
        player = GetComponent<Rigidbody>();
        vida = 10;
        cristales = 0;
        isMoving = false;
        anim = GetComponent<Animator>();
        last_shot = 0f;
        text.text = "HEALTH\n" + vida;
    }

    void FixedUpdate()
    {
        Move();
        Look();
        anim.SetBool("IsMoving", isMoving);
    }

    public void Move()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            player.transform.position += move * speed * Time.deltaTime;
            isMoving = true;
        }
        else
            isMoving = false;
    }

    public void Look()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            transform.LookAt(new Vector3(pointer.position.x, transform.position.y, pointer.position.z));
            Shoot();
        }
        else if(Input.GetAxis("Horizontal")!=0 || Input.GetAxis("Vertical")!=0)
            transform.LookAt(transform.position + new Vector3(move.x, 0, move.z));
    }

    public void Shoot()
    {
        if (Time.time - last_shot > 0.2)
        {
            GameObject bulletInst = Instantiate(bullet, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity);
            Transform bulletInstTransform = bulletInst.GetComponent<Transform>();
            bulletInstTransform.LookAt(pointer.position);
            Rigidbody bulletInstRigidbody = bulletInst.GetComponent<Rigidbody>();
            bulletInstRigidbody.AddForce(bulletInstTransform.forward * bulletSpeed);
            Destroy(bulletInst, 2f);
            
            last_shot = Time.time;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Pirate_Bullet"))
        {
            vida -= 1;
            Destroy(col.gameObject);
            if (vida <= 0)
                Destroy(this.gameObject);
            text.text = "HEALTH\n" + vida;
        }
        else if (col.CompareTag("Sword"))
        {
            vida -= 3;
            if (vida <= 0)
            {
                Destroy(this.gameObject);
                vida = 0;
            }

            text.text = "HEALTH\n" + vida;
        }
        else if (col.CompareTag("Pickup"))
        {
            cristales++;
            Destroy(col.gameObject);
            Count.fragments++;
        }

    }
}
