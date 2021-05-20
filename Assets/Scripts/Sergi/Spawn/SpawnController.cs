using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{

    public Transform[] spawnPositions;
    private int random;
    
    public IEnumerator spawnEnemies(GameObject Enemy, int number)
    {
        int remaining = number;

        while(remaining > 0)
        {
            yield return new WaitForSeconds(5f);
            random = Random.Range(0, spawnPositions.Length);
            Instantiate(Enemy, spawnPositions[random].position, Quaternion.identity).transform.parent = transform;
            remaining--;
        }
    }

}
