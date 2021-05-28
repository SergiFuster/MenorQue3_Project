using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSlider : MonoBehaviour
{
    private Slider slider;
    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color noHealthColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = PlayerControl.vida;
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth();
    }

    public void SetHealth()
    {
        slider.value = PlayerControl.vida;
        fillImage.color = Color.Lerp(noHealthColor, fullHealthColor, PlayerControl.vida / 10f);
    }
}
