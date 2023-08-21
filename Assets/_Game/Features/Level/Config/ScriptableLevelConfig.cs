using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Level Config")]
public class ScriptableLevelConfig : ScriptableObject, ILevelConfig
{
    [SerializeField] private Vector3 _playerStartPosition;
    public Vector3 PlayerStartPosition => _playerStartPosition;

    [SerializeField] private Vector3 _magneticFieldStartPosition;
    public Vector3 MagneticFieldStartPosition => _magneticFieldStartPosition;

    [SerializeField] private Vector3 _playAreaContainerOffset;
    public Vector3 PlayAreaContainerOffset => _playAreaContainerOffset;

    [SerializeField] private Vector2Int _playAreaContainerRotation;
    public Vector2Int PlayAreaContainerRotation => _playAreaContainerRotation;

    [SerializeField] private List<float> _levelTimers;
    public List<float> LevelTimers => _levelTimers;
}
