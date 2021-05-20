using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorManager : MonoBehaviour
{

    [SerializeField] RectTransform indicatorContainer = null;

    public static IndicatorManager manager;

    public Vector2 offset;

    Dictionary<TrackedObject, RectTransform> indicators = new Dictionary<TrackedObject, RectTransform>();

    private void Awake()
    {
        manager = this;
    }

    private void LateUpdate()
    {
        foreach (var pair in indicators)
        {
            TrackedObject target = pair.Key;
            RectTransform indicator = pair.Value;

            if (target == null)
            {
                continue;
            }

            indicator.anchoredPosition = GetCanvasPositionForTarget(target);
        }
    }

    private Vector2 GetCanvasPositionForTarget(TrackedObject target)
    {
        var indicatorPoint = Camera.main.WorldToViewportPoint(target.transform.position);

        indicatorPoint.x = Mathf.Clamp01(indicatorPoint.x);
        indicatorPoint.y = Mathf.Clamp01(indicatorPoint.y);

        if (indicatorPoint.z < 0)
        {
            indicatorPoint.y = 0;

            indicatorPoint.x = 1f - indicatorPoint.x;
        }

        var canvas = indicatorContainer.GetComponentInParent<Canvas>();

        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;

        indicatorPoint.Scale(canvasSize);

        indicatorPoint.x += offset.x;
        indicatorPoint.y += offset.y;

        return indicatorPoint;

    }

    public void AddTrackingIndicator(TrackedObject transform, RectTransform indicatorPrefab)
    {
        if (indicators.ContainsKey(transform))
        {
            return;
        }

        var indicator = Instantiate(indicatorPrefab);

        indicator.name = string.Format("Indicator for {0}", transform.gameObject.name);

        indicator.SetParent(indicatorContainer, false);

        indicator.pivot = new Vector2(0.5f, 0.5f);

        indicator.anchorMin = Vector2.zero;
        indicator.anchorMax = Vector2.zero;

        indicators[transform] = indicator;

        indicator.anchoredPosition = GetCanvasPositionForTarget(transform);

    }

    public void RemoveTrackingIndicator(TrackedObject transform)
    {
        if (indicators.ContainsKey(transform))
        {
            if (indicators[transform] != null)
            {
                Destroy(indicators[transform].gameObject);
            }
        }

        indicators.Remove(transform);
    }

}
