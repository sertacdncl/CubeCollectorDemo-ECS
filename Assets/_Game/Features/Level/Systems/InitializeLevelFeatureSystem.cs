using System.Collections.Generic;
using Entitas;
using Game;
using UnityEngine;

public sealed class InitializeLevelFeatureSystem : ReactiveSystem<GameEntity>, IInitializeSystem
{
    readonly Contexts _contexts;
    Transform _playAreaContainer;
    private int _levelCount;

    public InitializeLevelFeatureSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var levelInfo = Resources.Load<TextAsset>(LevelImportTags.LevelInfo).text;
        _levelCount = JsonUtility.FromJson<LevelInfo>(levelInfo).LevelCount;

        SetupLevel();
    }

    private void SetupLevel()
    {
        if (LevelService.PlayerCurrentLevel >= _levelCount)
            LevelService.PlayerCurrentLevel = Random.Range(0, _levelCount);
        var level = LevelService.PlayerCurrentLevel;
        _contexts.input.isInputBlock = true;
        var levelString = Resources.Load<TextAsset>(LevelImportTags.GetLevelName(level)).text;
        var data = JsonUtility.FromJson<LevelDataContainer>(levelString);

        CreateCubes(data, out var averagePos);
        CreatePlayAreaContainer(averagePos);
        CreatePlayer();
        CreateMagneticField();
        _contexts.game.isLevelReady = true;
        _contexts.input.isInputBlock = false;
    }

    private void CreatePlayAreaContainer(Vector3 averagePos)
    {
        if (_playAreaContainer != null)
        {
            _playAreaContainer.DetachChildren();
            GameObject.Destroy(_playAreaContainer.gameObject);
        }

        _playAreaContainer = new GameObject("PlayAreaContainer").transform;
        var levelConfig = _contexts.config.levelConfig.value;
        _playAreaContainer.position = new Vector3(-averagePos.x + levelConfig.PlayAreaContainerOffset.x,
            0 + levelConfig.PlayAreaContainerOffset.y, -averagePos.y + levelConfig.PlayAreaContainerOffset.z);
        _playAreaContainer.rotation = levelConfig.PlayAreaContainerRotation.GetEulerQuaternion();
        _contexts.game.ReplacePlayAreaParent(_playAreaContainer);
    }

    private void CreateCubes(LevelDataContainer data, out Vector3 averagePos)
    {
        var cubeCount = 0;
        var totalPos = Vector3.zero;
        foreach (var coloredPixelData in data.ColoredPixelList)
        {
            foreach (var pos in coloredPixelData.PixelList)
            {
                _contexts.game.CreatePixelCube(pos, coloredPixelData.Color);
                cubeCount++;
                totalPos += pos.ToViewPosition();
            }
        }

        averagePos = totalPos / cubeCount;
        _contexts.game.ReplaceCreatedCubeCount(cubeCount);
    }

    private void CreatePlayer()
    {
        var playerStartPosition = _contexts.config.levelConfig.value.PlayerStartPosition;
        _contexts.game.CreatePlayer(playerStartPosition);
    }

    private void CreateMagneticField()
    {
        var magneticFieldPos = _contexts.config.levelConfig.value.MagneticFieldStartPosition;
        _contexts.game.CreateMagneticField(magneticFieldPos);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
        context.CreateCollector(GameMatcher.LoadLevel);

    protected override bool Filter(GameEntity entity) => _contexts.game.isLevelEnd;

    protected override void Execute(List<GameEntity> entities)
    {
        var cubes = _contexts.game.GetEntities(GameMatcher.ColoredCube);
        foreach (var gameEntity in cubes)
        {
            gameEntity.isDestroyed = true;
        }
        var player = _contexts.game.GetEntities(GameMatcher.Player);
        foreach (var gameEntity in player)
        {
            gameEntity.isDestroyed = true;
        }

        _contexts.game.isLevelEnd = false;
        _contexts.game.ReplaceCurrentCollectedCubes(0);
        _contexts.game.ReplaceCreatedCubeCount(0);
        SetupLevel();
    }
}
