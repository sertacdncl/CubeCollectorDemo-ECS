using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Game/Player Config")]
public class ScriptablePlayerConfig : ScriptableObject, IPlayerConfig
{
    [SerializeField] float _speed;
    public float Speed => _speed;
}
