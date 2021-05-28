using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBomb : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Box")
        {
            Destroy(other.gameObject);
        }

    }
}
