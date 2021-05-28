using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    
    public GameObject Bullet;
    public float fireRate;
    public Transform firePoint;
    public float bulletVelocity;
    public float health;

    float nextTimeToFire = 0f;
    GameObject target;

    private void Start()
    {
        target = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 point = new Vector3(target.transform.position.x, this.transform.position.y, target.transform.position.z);
        this.transform.LookAt(point);

        

        


        if(Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            shoot();
        }
    }

    void shoot()
    {
        GameObject currentBullet = Instantiate(Bullet, firePoint.position, transform.rotation);
        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletVelocity, ForceMode.Impulse);
    }

    public void damageEnemy(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //partycles
        Destroy(this.gameObject.transform.parent.parent.gameObject);
        GameObject.Find("RoundManager").GetComponent<RoundController>().enemyKilled();
    }

}
