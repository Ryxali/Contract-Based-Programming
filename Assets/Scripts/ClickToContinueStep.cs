using UnityEngine;

public class ClickToContinueStep : MonoBehaviour, ISlideStep
{
    public void Enter()
    {
    }

    public void Exit()
    {
    }

    public bool MoveNext(ref PlayerInput input)
    {
        if (input.anyKeyDown)
        {
            input.anyKeyDown = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
