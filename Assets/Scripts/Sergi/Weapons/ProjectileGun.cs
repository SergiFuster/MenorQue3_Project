using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float bulletForwardVelocity;
    public float bulletUpwardVelocity;
    [Range(1,99)]
    public int chamberSize;
    [Range(1,999)]
    public int currentChamber;
    public bool holdToShot;
    public float reloadTime;
    public float fireRate = 15f;

    private bool isReloading = false;
    private float nextTimeToFire = 0f;

    private void Update()
    {
        if (isReloading) return;


        if(currentChamber <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (holdToShot)
        {
            if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet, transform.position, transform.rotation);
        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
        Vector3 bulletDirection = (PlayerMovement.mousePosition - transform.position).normalized * bulletForwardVelocity;
        bulletDirection.y = firePoint.position.y;
        rb.AddForce(bulletDirection, ForceMode.Impulse);
        rb.AddForce(transform.up * bulletUpwardVelocity, ForceMode.Impulse);
        currentChamber--;
        Debug.Log("Ammo: " + currentChamber);
    }

    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentChamber = chamberSize;

        Debug.Log("Reloaded!");

        isReloading = false;


    }
}
