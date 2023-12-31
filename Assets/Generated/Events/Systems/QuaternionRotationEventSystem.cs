//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class QuaternionRotationEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<IQuaternionRotationListener> _listenerBuffer;

    public QuaternionRotationEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<IQuaternionRotationListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.QuaternionRotation)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasQuaternionRotation && entity.hasQuaternionRotationListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.quaternionRotation;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.quaternionRotationListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnQuaternionRotation(e, component.Value);
            }
        }
    }
}
