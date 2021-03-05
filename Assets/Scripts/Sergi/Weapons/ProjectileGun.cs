using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    /*public float reloadTime;
    public float ammoAmount;
    public float currentAmmo;*/
    public float bulletVelocity;

    //private bool recharging;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        GameObject currentBullet = Instantiate(bullet, transform.position, transform.rotation);
        currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletVelocity, ForceMode.Impulse);
    }
}
