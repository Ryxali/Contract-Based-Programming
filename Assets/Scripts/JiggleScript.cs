using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiggleScript : MonoBehaviour
{
    [SerializeField]
    private float offset;
    [SerializeField]
    private float interval;
    [SerializeField]
    private float amount;

    private float next;
    private bool flipFlop;

    private RectTransform rectTransform;
    private Vector3 rootPosition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        rootPosition = rectTransform.anchoredPosition;
    }

    private void OnEnable()
    {
        next = Time.time + offset;
    }

    private void Update()
    {
        if (next < Time.time)
        {
            if (flipFlop)
            {
                rectTransform.anchoredPosition = rootPosition;
            }
            else
            {
                rectTransform.anchoredPosition = rootPosition + Vector3.up * amount;
            }
            flipFlop = !flipFlop;
            next += interval;
        }
    }
}
