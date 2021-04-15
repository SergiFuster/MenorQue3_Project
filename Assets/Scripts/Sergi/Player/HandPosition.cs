using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPosition : MonoBehaviour
{
    [SerializeField]
    public Transform leftHand;
    public Transform rightHand;
    public void SetHandsPosition(Transform newLeft, Transform newRight)
    {

        leftHand.position = newLeft.position;
        leftHand.rotation = newLeft.rotation;
        rightHand.position = newRight.position;
        rightHand.rotation = newRight.rotation;
    }

}
