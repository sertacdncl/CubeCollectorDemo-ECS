public sealed class LevelFeature : Feature
{
    public LevelFeature(Contexts contexts)
    {
        Add(new InitializeLevelFeatureSystem(contexts));
    }
}
