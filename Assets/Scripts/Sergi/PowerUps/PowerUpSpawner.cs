using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] PowerUps;

    int random;
    int randomPowerUp;
    int randomSpawnPoint;

    const int chance = 1;
    
    

    private void Start()
    {
        StartCoroutine(spawnPowerUps());
    }

    
    IEnumerator spawnPowerUps()
    {
        while(true) //PLAYING
        {
            random = Random.Range(0, 100);
            if(random <= chance)
            {
                randomSpawnPoint = Random.Range(0, spawnPoints.Length);
                randomPowerUp = Random.Range(0, PowerUps.Length);
                Instantiate(PowerUps[randomPowerUp], spawnPoints[randomSpawnPoint].position, Quaternion.identity);
                Debug.Log("POWERUP HAVE SPAWNED");
            }

            yield return new WaitForSeconds(10f);
        }
    }


}

