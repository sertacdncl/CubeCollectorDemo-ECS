//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class GameEventSystems : Feature {

    public GameEventSystems(Contexts contexts) {
        Add(new ColliderEventSystem(contexts)); // priority: 0
        Add(new ColorEventSystem(contexts)); // priority: 0
        Add(new AnyCurrentCollectedCubesEventSystem(contexts)); // priority: 0
        Add(new AnyCurrentLevelEventSystem(contexts)); // priority: 0
        Add(new AnyCurrentLevelRemovedEventSystem(contexts)); // priority: 0
        Add(new DestroyedEventSystem(contexts)); // priority: 0
        Add(new AnyLevelEndEventSystem(contexts)); // priority: 0
        Add(new AnyLevelReadyEventSystem(contexts)); // priority: 0
        Add(new AnyPlayAreaParentEventSystem(contexts)); // priority: 0
        Add(new PositionEventSystem(contexts)); // priority: 0
        Add(new QuaternionRotationEventSystem(contexts)); // priority: 0
        Add(new RigidbodyEventSystem(contexts)); // priority: 0
        Add(new RotationEventSystem(contexts)); // priority: 0
        Add(new ScaleEventSystem(contexts)); // priority: 0
        Add(new AnyTimeTickEventSystem(contexts)); // priority: 0
    }
}
