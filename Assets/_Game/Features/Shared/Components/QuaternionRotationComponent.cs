using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self)]
public sealed class QuaternionRotationComponent : IComponent
{
    public Quaternion Value;
}

