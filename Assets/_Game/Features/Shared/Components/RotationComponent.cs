using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public sealed class RotationComponent : IComponent
{
    public Vector2Int Value;
}
