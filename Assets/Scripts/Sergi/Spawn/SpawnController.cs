using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public Transform[] spawnPositions;
    private int randomPoint;
    private int randomEnemy;
    
    public IEnumerator spawnEnemies(GameObject[] enemies, int number)
    {
        int remaining = number;

        while(remaining > 0)
        {
            
            yield return new WaitForSeconds(5f);
            randomEnemy = Random.Range(0, enemies.Length);
            randomPoint = Random.Range(0, spawnPositions.Length);
            Instantiate(enemies[randomEnemy], spawnPositions[randomPoint].position, Quaternion.identity, transform);
            remaining--;
        }
    }

}
