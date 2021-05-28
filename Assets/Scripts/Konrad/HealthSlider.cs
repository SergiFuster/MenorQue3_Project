using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    //public static int health;
    private Quaternion relativeRotation;
    //private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        //health = 10;
        //slider = GetComponent<Slider>();
        //slider.value = health;
        relativeRotation = transform.parent.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = relativeRotation;
        //SetHealth();
    }

    public void SetHealth()
    {
       
    }
}
