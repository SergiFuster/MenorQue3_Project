using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Image lifeBar;
    public float hpMax = 100f;
    public float hpNow;


    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        hpNow = FindObjectOfType<PMovement>().hpNow;
        lifeBar.fillAmount = hpNow / hpMax;
    }
}
