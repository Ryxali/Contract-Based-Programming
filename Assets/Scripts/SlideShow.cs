using System.Collections;
using UnityEngine;

public class SlideShow : MonoBehaviour
{
    private SlideSequence slideSequence;

    private void Awake()
    {
        slideSequence = new SlideSequence(transform);
    }

    private IEnumerator Start()
    {
        while (slideSequence.MoveNext())
        {
            yield return null;
        }
        Debug.Log("Done!");
        //slideSequence.Enter();
        //bool isDone = false;
        //while(!isDone)
        //{
        //    slideSequence.Tick(out isDone);
        //    yield return null;
        //}
        //slideSequence.Exit();
    }
}
