using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpSystem : MonoBehaviour
{
    public ProjectileGun gunScript;
    public Transform player, gunContainer;
    public Rigidbody rb;
    public Transform rightHand;
    public Transform leftHand;
    public HandPosition Hands;
    public int gunPrice;
    public Sprite wImage;
    public WeaponUI weaponImage;

    public TrackedObject indicator;

    private float pickUpRange = 3;
    public  MoneyController wallet;

    public bool equipped;
    public static bool slotFull;

    public AmmoBar ammoBar;

    private void Start()
    {
        //Add this weapon to price manager Game Object array
        PriceManager.manager.addWeapon(this.gameObject);

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

        if(distanceToPlayer.magnitude <= pickUpRange)
        {
            if (!equipped && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();
            else if (!equipped && Input.GetKeyDown(KeyCode.E) && slotFull)
            {
                PickUp();
            }
        }
        

    }


    private void PickUp()
    {
        if (gunPrice <= MoneyController.Money)
        {
            //Set ammo bar UI values
            ammoBar.setMaxAmmo(gunScript.chamberSize);

            //Remove this weapon from price manager Game Object array
            PriceManager.manager.removeWeapon(this.gameObject);

            deleteCurrentWeapon();

            weaponImage.setWeaponImage(wImage); //Change Weapon image

            gunScript.updateAmmoText();

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

            //Delete indicator
            indicator.deleteIndicator();
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
