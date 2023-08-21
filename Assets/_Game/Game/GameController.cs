using System;
using Entitas;

/**
 *
 * The GameController creates and manages all systems in Game
 *
 */
public class GameController
{
    readonly Systems _systems;
    readonly Contexts _contexts;

    public GameController(Contexts contexts, IGameConfig gameConfig)
    {
        _contexts = contexts;
        var random = new Random(DateTime.UtcNow.Millisecond);
        UnityEngine.Random.InitState(random.Next());
        Rand.game = new Rand(random.Next());

        contexts.config.SetGameConfig(gameConfig);

        // This is the heart of Game:
        // All logic is contained in all the sub systems of GameSystems
        _systems = new GameSystems(contexts);
    }

    public void ReplaceLevelConfig(ILevelConfig levelConfig)
    {
        _contexts.config.ReplaceLevelConfig(levelConfig);
    }

    public void ReplacePlayerConfig(IPlayerConfig playerConfig)
    {
        _contexts.config.ReplacePlayerConfig(playerConfig);
    }

    public void Initialize()
    {
        // This calls Initialize() on all sub systems
        _systems.Initialize();
    }

    public void Execute()
    {
        // This calls Execute() and Cleanup() on all sub systems
        _systems.Execute();
        _systems.Cleanup();
    }
}
