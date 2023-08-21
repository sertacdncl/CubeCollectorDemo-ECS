using System.Collections.Generic;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Config, Unique, ComponentName("LevelConfig")]
public interface ILevelConfig
{
    Vector3 PlayerStartPosition { get; }
    Vector3 MagneticFieldStartPosition { get; }
    Vector3 PlayAreaContainerOffset { get; }
    Vector2Int PlayAreaContainerRotation { get; }
    List<float> LevelTimers { get; }
}
