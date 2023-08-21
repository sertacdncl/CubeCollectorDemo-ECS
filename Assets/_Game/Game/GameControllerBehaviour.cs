using DG.Tweening;
using UnityEngine;

/**
 *
 * GameControllerBehaviour is the entry point to Game
 *
 * The only purpose of this class is to redirect and forward
 * the Unity lifecycle events to the GameController
 *
 */
public class GameControllerBehaviour : MonoBehaviour
{
    public ScriptableGameConfig GameConfig;
    public ScriptableLevelConfig LevelConfig;
    public ScriptablePlayerConfig PlayerConfig;

    GameController _gameController;

    void Awake()
    {
        DOTween.SetTweensCapacity(500, 50);
        _gameController = new GameController(Contexts.sharedInstance, GameConfig);
        _gameController.ReplaceLevelConfig(LevelConfig);
        _gameController.ReplacePlayerConfig(PlayerConfig);
    }

    void Start() => _gameController.Initialize();
    void Update() => _gameController.Execute();
}
