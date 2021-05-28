using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLifeBar : MonoBehaviour
{
    

    public Image enemyLifeBar;
    public float enemyHpMax = 100f;
    public float enemyHpNow;

    public Animator m_EnemyAnim; 



    // Start is called before the first frame update
    void Start()
    {
        m_EnemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyHpNow = FindObjectOfType<EnemyDavid_Script>().enemyHpNow;
        enemyLifeBar.fillAmount = enemyHpNow / enemyHpMax;

        if(enemyHpNow <= 0)
        {
            EnemyDie();
        }
    }

    void EnemyDie()
    {
        m_EnemyAnim.SetBool("Die1", true);
    }
}
