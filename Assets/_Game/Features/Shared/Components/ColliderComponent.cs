using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public sealed class ColliderComponent : IComponent
{
    public bool IsEnabled;
    public bool IsTrigger;
}

