using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{

    public GameObject bullet;
    public Transform spawnPoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
