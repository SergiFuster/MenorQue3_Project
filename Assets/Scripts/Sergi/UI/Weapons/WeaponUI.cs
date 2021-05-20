using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Image image;

    private void Start()
    {
        var alpha = image.color;
        alpha.a = 0f;
        image.color = alpha;


    }
    public void setWeaponImage(Sprite wImage)
    {
        var alpha = image.color;
        alpha.a = 1f;
        image.color = alpha;
        image.sprite = wImage;
    }
}
