using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBombUp : MonoBehaviour
{
    public int n;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Cambia el texto para que aumente el contador de bombas
            int n = other.GetComponent<PMovement>().nBombs += 1;
            
            other.GetComponent<PMovement>().nBombsText.text = n.ToString();
            Destroy(gameObject);
        }
    }
}
