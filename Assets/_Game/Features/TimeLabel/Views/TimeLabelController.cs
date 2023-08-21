using System;
using Entitas;
using Game;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeLabelController : MonoBehaviour, IAnyTimeTickListener, IAnyLevelReadyListener
{
    public TMP_Text Label;
    [SerializeField] private Image timeFill;

    private float _startTime;
    private float _passedTime;
    private Contexts contexts;
    private GameEntity listener;
    void Start()
    {
        contexts = Contexts.sharedInstance;
        listener = contexts.game.CreateEntity();
        listener.AddAnyTimeTickListener(this);
        listener.AddAnyLevelReadyListener(this);
    }

    public void OnAnyTimeTick(GameEntity entity)
    {
        _passedTime++;
        Label.text = $"{(int)(_startTime - _passedTime)}";
        timeFill.fillAmount = (_startTime-_passedTime) / _startTime;
        if (Math.Abs(_passedTime - _startTime) < 0.1f)
        {
            contexts.input.isInputBlock = true;
            contexts.game.isLevelReady = false;
            contexts.game.isLevelEnd = true;
            listener.RemoveAnyTimeTickListener(this);
        }
    }

    public void OnAnyLevelReady(GameEntity entity)
    {
        if (!contexts.game.isLevelReady)
            return;

        if(!listener.hasAnyTimeTickListener)
            listener.AddAnyTimeTickListener(this);

        var levelConfig = contexts.config.levelConfig.value;
        var time = levelConfig.LevelTimers[LevelService.PlayerCurrentLevel];
        _startTime = time;
        _passedTime = 0;
        timeFill.fillAmount = 1;

        Label.text = $"{(int)time}";
    }
}
