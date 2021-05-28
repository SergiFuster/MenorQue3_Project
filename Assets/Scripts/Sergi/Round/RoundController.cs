using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public SpawnController spawner;
    public GameObject[] enemies;
    public int Round;
    public int initialEnemies;
    private int amountOfEnemies;
    private int currentEnemies;
    public RoundUI roundText;
    private void Start()
    {
        currentEnemies = initialEnemies;
        roundText.updateRound(Round);
        
    }

    public void enemyKilled()
    {
        currentEnemies--;
        if(currentEnemies <= 0)
        {
            Round++;
            amountOfEnemies = Round * 10 / 2;
            currentEnemies = amountOfEnemies;
            roundText.updateRound(Round); //Update round UI
            StartCoroutine(spawner.spawnEnemies(enemies, amountOfEnemies));
        }

    }
}
