using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Count : MonoBehaviour
{
    public int Score;

    void Start()
    {
        Score = 0;
    }

    private void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Jugador")
        {
            gameObject.SetActive(false);
            Debug.Log("Fragment entered");
        }
    }
}
