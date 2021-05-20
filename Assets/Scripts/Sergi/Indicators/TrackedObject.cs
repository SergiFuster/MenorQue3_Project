using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackedObject : MonoBehaviour
{
    public RectTransform spriteIndicator;
    private void Start()
    {
        IndicatorManager.manager.AddTrackingIndicator(this, spriteIndicator);
    }

    public void deleteIndicator()
    {
        IndicatorManager.manager.RemoveTrackingIndicator(this);
    }
}
