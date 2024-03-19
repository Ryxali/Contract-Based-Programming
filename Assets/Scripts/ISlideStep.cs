using System.Collections;
using UnityEngine;

public interface ISlideStep
{
    void Enter();
    void Exit();
    bool MoveNext(ref PlayerInput input);
}