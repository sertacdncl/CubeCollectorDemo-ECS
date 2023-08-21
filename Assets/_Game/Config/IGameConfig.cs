using Entitas.CodeGeneration.Attributes;

[Config, Unique, ComponentName("GameConfig")]
public interface IGameConfig
{
    float InputThreshold { get; }
}
