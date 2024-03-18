using UnityEngine;

public class ClickRevealStep : MonoBehaviour, ISlideStep
{
    public bool IsRoot => false;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Enter()
    {
        gameObject.SetActive(true);
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
