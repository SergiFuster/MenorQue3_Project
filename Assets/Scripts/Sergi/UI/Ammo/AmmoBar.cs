using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField]
    public Slider slider;
    public Image fill;


    public void setMaxAmmo(float ammo)
    {
        slider.maxValue = ammo;
        slider.value = ammo;
    }
    public void setAmmo(float ammo)
    {
        slider.value = ammo;
    }
}
