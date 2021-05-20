using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Animator anim;

    public void setAmmoText(float ammo)
    {
        text.text = ammo.ToString();
    }

    public void reloadingAnimation(bool play)
    {
        anim.SetBool("reloading", play);
    }

}
