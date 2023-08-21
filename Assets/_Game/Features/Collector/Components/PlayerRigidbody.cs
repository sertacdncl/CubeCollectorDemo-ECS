using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Unique]
public sealed class PlayerRigidbody : IComponent
{
    public Rigidbody Value;
}

