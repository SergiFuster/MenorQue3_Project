using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitByPlayer : MonoBehaviour
{
    private int vida;
    private Slider slider;

    public Image fillImage;
    public Color fullHealthColor = Color.green;
    public Color noHealthColor = Color.red;

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        AssignHealth();
        slider = GetComponentInChildren<Slider>();
        slider.maxValue = vida;
        slider.value = vida;
        fillImage.color = fullHealthColor;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(vida<=0)
            Die();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player_Bullet"))
        {
            vida -= 1;
            slider.value = vida;
            Destroy(col.gameObject);
            fillImage.color = Color.Lerp(noHealthColor, fullHealthColor, vida / 8f);
        }
    }

    public void AssignHealth()
    {
        if (gameObject.tag == "Sword_Pirate")
            vida = 10;
        else if (gameObject.tag == "Gun_Pirate")
            vida = 5;
    }

    public void Die()
    {
        Destroy(gameObject);
        GameObject explInst = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(explInst.gameObject, 1f);
        if (PlayerControl.vida < 10)
            PlayerControl.vida++;
    }
}
