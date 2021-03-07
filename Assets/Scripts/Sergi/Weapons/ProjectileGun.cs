using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProjectileGun : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float bulletVelocity;
    [Range(1,99)]
    public int chamberSize;
    [Range(1,999)]
    public int barrelSize;
    public int currentChamber;
    public int currentBarrel;
    public float reloadTime;
    public TextMeshProUGUI currentChamberAmmo;
    public TextMeshProUGUI currentBarrelAmmo;

    private bool isReloading = false;

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


        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject currentBullet = Instantiate(bullet, transform.position, transform.rotation);
        currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletVelocity, ForceMode.Impulse);
        currentChamber--;
        currentChamberAmmo.text = currentChamber.ToString();
    }

    IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);

        if(currentBarrel >= chamberSize)
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

        isReloading = false;
    }
}
