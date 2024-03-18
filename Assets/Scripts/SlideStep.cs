using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideStep : MonoBehaviour, ISlideStep
{
    [SerializeField]
    private Vector3 from, to;
    [SerializeField]
    private AnimationCurve animationCurve;

    private bool finished;
    private bool running;

    public void Enter()
    {
        if (!finished && !running)
        {
            running = true;
            StartCoroutine(Animate());
        }
    }

    public void Exit()
    {
        finished = true;
    }

    public bool MoveNext(ref PlayerInput input)
    {
        return finished;
    }

    private IEnumerator Animate()
    {
        var rt = GetComponent<RectTransform>();
        var now = Time.time;
        var end = now + animationCurve.keys[animationCurve.keys.Length - 1].time;
        while (Time.time < end)
        {
            rt.anchoredPosition = Vector3.Lerp(from, to, animationCurve.Evaluate(Time.time - now));
            yield return null;
        }
        rt.anchoredPosition = to;
        finished = true;
    }
}
