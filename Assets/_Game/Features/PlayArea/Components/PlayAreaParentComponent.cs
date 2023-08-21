using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Unique, Event(EventTarget.Any)]
public sealed class PlayAreaParentComponent : IComponent
{
    public Transform Value;
}

