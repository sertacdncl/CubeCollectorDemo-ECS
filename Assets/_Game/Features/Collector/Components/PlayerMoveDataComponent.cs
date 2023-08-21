using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Unique]
public sealed class PlayerMoveDataComponent : IComponent
{
    public Vector3 Velocity;
    public Quaternion Rotation;
}

