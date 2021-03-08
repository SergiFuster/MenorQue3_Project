using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    public ProjectileGun gunScript;
    public Transform player, gunContainer;
    public Canvas canvas;

    private float pickUpRange = 3;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        //Setup
        if (!equipped)
        {
            canvas.enabled = false;
            gunScript.enabled = false;
        }
        else
        {
            canvas.enabled = true;
            gunScript.enabled = true;
            slotFull = true;
        }

    }

    private void Update()
    {
        //Check if player is in range and E is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();
        else if(!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && slotFull)
        {
            deleteCurrentWeapon();
            PickUp();
        }
        

    }

    private void PickUp()
    {
        canvas.enabled = true;
        equipped = true;
        slotFull = true;

        // Make weapon a child of weapon container and move it to default position
        transform.SetParent(gunContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //Enable script
        gunScript.enabled = true;
    }

    private void deleteCurrentWeapon()
    {
        foreach(Transform child in GameObject.Find("WeaponContainer").GetComponent<Transform>())
        {
            Destroy(child.gameObject);
        }
    }
}
