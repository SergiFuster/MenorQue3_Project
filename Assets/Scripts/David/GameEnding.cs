using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;

    public CanvasGroup youWinBackgroundImage;
    public CanvasGroup gameOverBackgroundImage;

    bool m_IsPlayerGameOver;
    bool m_IsPlayerWin;
    float m_Timer;

    // Update is called once per frame
    void Update()
    {
        CheckPlayerHp();
        CheckEnemyHp();

        if (m_IsPlayerWin)
        {
            EndLevel(youWinBackgroundImage, false);

        } else if (m_IsPlayerGameOver)
        {
            EndLevel(gameOverBackgroundImage, true);
        }
    }

    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        m_Timer += Time.deltaTime;

        imageCanvasGroup.alpha = m_Timer / fadeDuration;

        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
    void CheckPlayerHp()
    {
        if (FindObjectOfType<PMovement>().hpNow <= 0)
        {
            m_IsPlayerGameOver = true;
        }
    }

    void CheckEnemyHp()
    {
        if(FindObjectOfType<EnemyDavid_Script>().enemyHpNow <= 0)
        {
            m_IsPlayerWin = true;
        }
    }
}
