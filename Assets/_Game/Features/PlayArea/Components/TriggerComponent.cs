using Entitas;
using UnityEngine;


public sealed class TriggerComponent : IComponent
{
    public GameEntity Self;
    public GameEntity Other;
    public GameObject SelfView;
    public GameObject OtherView;

}

