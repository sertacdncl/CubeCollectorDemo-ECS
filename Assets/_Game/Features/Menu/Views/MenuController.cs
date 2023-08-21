using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour, IAnyLevelEndListener
{
    [SerializeField] private GameObject _failedPanel;
    [SerializeField] private GameObject _completePanel;

    private Contexts contexts;
    private GameEntity listener;

    void Start()
    {
        contexts = Contexts.sharedInstance;
        listener = contexts.game.CreateEntity();
        listener.AddAnyLevelEndListener(this);
    }

    public void OnAnyLevelEnd(GameEntity entity)
    {
        var collectedCubes = contexts.game.hasCurrentCollectedCubes
            ? contexts.game.currentCollectedCubes.Value
            : 0;
        var isComplete = collectedCubes >= contexts.game.createdCubeCount.Value / 2;
        _failedPanel.SetActive(!isComplete);
        _completePanel.SetActive(isComplete);
    }

    public void NextLevel()
    {
        LevelService.PlayerCurrentLevel++;
        Load();
    }

    public void TryAgain()
    {
        Load();
    }

    private void Load()
    {
        _failedPanel.SetActive(false);
        _completePanel.SetActive(false);
        contexts.game.CreateEntity().isLoadLevel = true;
    }
}
