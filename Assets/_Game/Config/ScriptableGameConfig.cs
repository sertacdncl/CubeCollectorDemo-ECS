using UnityEngine;

[CreateAssetMenu(menuName = "Game/Game Config")]
public class ScriptableGameConfig : ScriptableObject, IGameConfig
{
    [SerializeField] float _inputThreshold;
    public float InputThreshold => _inputThreshold;
}
