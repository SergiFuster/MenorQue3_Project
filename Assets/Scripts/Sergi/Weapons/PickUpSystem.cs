using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSystem : MonoBehaviour
{
    public ProjectileGun gunScript;
    public Transform player, gunContainer;
    public Rigidbody rb;
    public Transform rightHand;
    public Transform leftHand;
    public HandPosition Hands;
    public int gunPrice;

    private float pickUpRange = 3;
    public  MoneyController wallet;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        //Setup
        if (!equipped)
        {
            gunScript.enabled = false;
            rb.isKinematic = false;
        }
        else
        {
            gunScript.enabled = true;
            slotFull = true;
            rb.isKinematic = true;
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
        if (gunPrice <= wallet.Money)
        {
            wallet.buyGun(gunPrice); //Discount gun price from wallet
            equipped = true;
            slotFull = true;

            //Enable Kinematic
            rb.isKinematic = true;

            // Make weapon a child of weapon container and move it to default position
            transform.SetParent(gunContainer);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);

            //Enable script
            gunScript.enabled = true;

            //Set hands position
            Hands.SetHandsPosition(leftHand, rightHand);
        }
        else
        {
            Debug.Log("You have not enough money");
        }
        
        
    }

    private void deleteCurrentWeapon()
    {
        foreach(Transform child in GameObject.Find("WeaponContainer").GetComponent<Transform>())
        {
            if (child.tag == "Secondary Weapon")
                Destroy(child.gameObject);
            else child.gameObject.SetActive(false);
        }
    }
}
