public sealed class CollectorFeature : Feature
{
    public CollectorFeature(Contexts contexts)
    {
        Add(new PlayerMoveSystem(contexts));
    }
}

