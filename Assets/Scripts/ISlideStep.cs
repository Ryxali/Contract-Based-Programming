using UnityEngine;

public interface ISlideStep
{
    void Enter();
    void Exit();
    bool MoveNext(ref PlayerInput input);
}

public struct Item
{
    public string name;
    public Sprite icon;
}

public interface IInventory
{
    void Add(Item item);
    void Remove(Item item);
}