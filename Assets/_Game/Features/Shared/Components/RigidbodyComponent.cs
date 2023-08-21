using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self), Cleanup(CleanupMode.RemoveComponent)]
public sealed class RigidbodyComponent : IComponent
{
    public bool IsKinematic;
    public Vector3 Velocity;
}

