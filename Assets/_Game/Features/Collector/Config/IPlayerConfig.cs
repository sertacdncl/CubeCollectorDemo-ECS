using Entitas.CodeGeneration.Attributes;

[Config, Unique, ComponentName("PlayerConfig")]
public interface IPlayerConfig
{
    float Speed { get; }
}
