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
    public int barrelSize;
    public int currentChamber;
    public int currentBarrel;
    public bool holdToShot;
    public float reloadTime;
    public float fireRate = 15f;
    public TextMeshProUGUI currentChamberAmmo;
    public TextMeshProUGUI currentBarrelAmmo;

    private bool isReloading = false;
    private float nextTimeToFire = 0f;

    private void Start()
    {
        currentBarrelAmmo.text = currentBarrel.ToString();
        currentChamberAmmo.text = currentChamber.ToString();
    }



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
        rb.AddForce((PlayerMovement.mousePosition - transform.position).normalized * bulletForwardVelocity, ForceMode.Impulse);
        rb.AddForce(transform.up * bulletUpwardVelocity, ForceMode.Impulse);
        currentChamber--;
        currentChamberAmmo.text = currentChamber.ToString();
    }

    IEnumerator Reload()
    {
        isReloading = true;

        if (currentBarrel > 0)
        {
            Debug.Log("Reloading...");

            yield return new WaitForSeconds(reloadTime);

            if (currentBarrel >= chamberSize)
            {
                currentChamber = chamberSize;
                currentBarrel -= chamberSize;
            }
            else
            {
                currentChamber = currentBarrel;
                currentBarrel = 0;
            }
            currentBarrelAmmo.text = currentBarrel.ToString();
            currentChamberAmmo.text = currentChamber.ToString();
        }
        else
        {
            Debug.Log("No ammo");
        }

        isReloading = false;


    }
}
