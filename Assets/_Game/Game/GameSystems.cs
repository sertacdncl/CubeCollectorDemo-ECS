public sealed class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        //Level
        Add(new LevelFeature(contexts));

        // Input
        Add(new InputFeature(contexts));


        // View
        Add(new ViewFeature(contexts));

        // Player
        Add(new CollectorFeature(contexts));

        // Play Area
        Add(new PlayAreaFeature(contexts));

        //Time
        Add(new TimeFeature(contexts));

        // Events (Generated)
        Add(new GameEventSystems(contexts));

        // Cleanup (Generated)
        Add(new GameCleanupSystems(contexts));
    }
}
