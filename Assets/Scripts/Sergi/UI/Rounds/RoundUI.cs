using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundUI : MonoBehaviour
{
    [SerializeField]public TextMeshProUGUI text;

    //animation
    public Animator anim;

    public void updateRound(float round)
    {
        StartCoroutine(changeRound(round));
    }

    IEnumerator changeRound(float round)
    {
        //play animation
        anim.SetBool("passing", true);
        //play round passed sound ???
        yield return new WaitForSeconds(4f);
        //stop animation
        anim.SetBool("passing", false);
        text.text = round.ToString();

    }
}
