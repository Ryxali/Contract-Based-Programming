using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SlideSequence
{
    private readonly List<ISlideStep[]> steps = new List<ISlideStep[]>();
    private int index;

    public SlideSequence(Transform root)
    {
        var stack = new Stack<(Transform transform, ISlideStep[] parents)>();
        stack.Push((root, System.Array.Empty<ISlideStep>()));
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            var array = current.parents;
            if (current.transform.TryGetComponent<ISlideStep>(out var step))
            {
                array = array.Append(step).ToArray();
                if (array.Length > 0)
                {
                    Debug.Log($"Add {array.Length}, {current.transform}");
                    steps.Add(array);
                }
            }
            for (int i = current.transform.childCount - 1; i >= 0; i--)
            {
                var child = current.transform.GetChild(i);
                stack.Push((child, array));
            }
        }
        index = -1;
    }

    public bool MoveNext()
    {
        if (index < 0)
        {
            index = 0;
            foreach (var step in steps[index])
                step.Enter();
            Debug.Log("Enter");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            bool moveNext = true;
            while (index > 0 && moveNext)
            {
                var prev = steps[index].Except(steps[index - 1]);
                foreach (var step in prev)
                {
                    step.Exit();
                }
                index--;
                foreach (var next in steps[index].Except(prev))
                {
                    next.Enter();
                }
                var inp = new PlayerInput { anyKeyDown = false };
                moveNext = steps[index].Last().MoveNext(ref inp);
            }
        }
        else
        {
            var inp = new PlayerInput
            {
                anyKeyDown = Input.anyKeyDown
            };
            while (index < steps.Count && steps[index].Last().MoveNext(ref inp))
            {
                if (index + 1 < steps.Count)
                {
                    var prev = steps[index].Except(steps[index + 1]);
                    foreach (var step in prev)
                    {
                        step.Exit();
                    }
                    index++;
                    foreach (var next in steps[index].Except(prev))
                    {
                        next.Enter();
                    }
                }
                else
                {
                    foreach (var step in steps[index])
                    {
                        step.Exit();
                    }
                    index++;
                }
            }
        }
        return index < steps.Count;
    }
}

