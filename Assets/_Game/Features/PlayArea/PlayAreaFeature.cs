public sealed class PlayAreaFeature : Feature
{
    public PlayAreaFeature(Contexts contexts)
    {
        Add(new MagneticFieldSystem(contexts));
    }
}

