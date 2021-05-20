using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class PriceManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> weapons;
    public GameObject player;
    public float distance;
    public Animator priceAnimator;
    public TextMeshProUGUI priceText;
    

    public static PriceManager manager;

    private void Awake()
    {
        manager = this;
    }

    private void Update()
    {
        

        if(weapons.Count > 0)
        { 
            foreach(GameObject weapon in weapons)
            {
                weapons = weapons.OrderBy(weapon => Vector2.Distance(weapon.transform.position, player.transform.position)).ToList();
            }
            if ((weapons[0].transform.position - player.transform.position).magnitude <= distance)
            {
                showUI();
            }
            else
            {
                priceAnimator.SetBool("active", false);
            }
        }
        else
        {
            priceAnimator.SetBool("active", false);
        }
        

    }

    public void showUI()
    {
        priceAnimator.SetBool("active", true);
        priceText.text = "- " + weapons[0].GetComponent<PickUpSystem>().gunPrice + "$";
    }

    public void addWeapon(GameObject weapon)
    {
        weapons.Add(weapon);

    }

    public void removeWeapon(GameObject weapon)
    {
        weapons.Remove(weapon);
    }
}
