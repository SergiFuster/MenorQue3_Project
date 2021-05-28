using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashController : MonoBehaviour
{
    public float timeToRemove;

    float timer;

    private void Start()
    {
        timer = timeToRemove;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            vaciarPapelera();
            timer = timeToRemove;
        }
    }

    void vaciarPapelera()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
