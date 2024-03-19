using UnityEngine;

public class SlidePage : MonoBehaviour, ISlideStep
{
    [SerializeField]
    private bool lastOne = false;
    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Enter()
    {
        Debug.Log("Enter Page", this);
        gameObject.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("Exit Page", this);
        gameObject.SetActive(false);
    }

    public bool MoveNext(ref PlayerInput input)
    {
        return !lastOne;
    }
}
