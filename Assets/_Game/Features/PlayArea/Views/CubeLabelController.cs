using System;
using Entitas;
using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CubeLabelController : MonoBehaviour, IAnyCurrentCollectedCubesListener, IAnyLevelReadyListener
{
    public TMP_Text Label;

    private Contexts contexts;
    private GameEntity listener;
    void Start()
    {
        contexts = Contexts.sharedInstance;
        listener = contexts.game.CreateEntity();
        listener.AddAnyCurrentCollectedCubesListener(this);
        listener.AddAnyLevelReadyListener(this);
    }

    public void OnAnyCurrentCollectedCubes(GameEntity entity, int value)
    {
        Label.text = $"{value} / {contexts.game.createdCubeCount.Value}";
    }

    public void OnAnyLevelReady(GameEntity entity)
    {
        Label.text = $"0 / {contexts.game.createdCubeCount.Value}";
    }
}
