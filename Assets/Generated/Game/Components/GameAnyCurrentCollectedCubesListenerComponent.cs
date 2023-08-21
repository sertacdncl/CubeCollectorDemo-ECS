//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyCurrentCollectedCubesListenerComponent anyCurrentCollectedCubesListener { get { return (AnyCurrentCollectedCubesListenerComponent)GetComponent(GameComponentsLookup.AnyCurrentCollectedCubesListener); } }
    public bool hasAnyCurrentCollectedCubesListener { get { return HasComponent(GameComponentsLookup.AnyCurrentCollectedCubesListener); } }

    public void AddAnyCurrentCollectedCubesListener(System.Collections.Generic.List<IAnyCurrentCollectedCubesListener> newValue) {
        var index = GameComponentsLookup.AnyCurrentCollectedCubesListener;
        var component = (AnyCurrentCollectedCubesListenerComponent)CreateComponent(index, typeof(AnyCurrentCollectedCubesListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyCurrentCollectedCubesListener(System.Collections.Generic.List<IAnyCurrentCollectedCubesListener> newValue) {
        var index = GameComponentsLookup.AnyCurrentCollectedCubesListener;
        var component = (AnyCurrentCollectedCubesListenerComponent)CreateComponent(index, typeof(AnyCurrentCollectedCubesListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyCurrentCollectedCubesListener() {
        RemoveComponent(GameComponentsLookup.AnyCurrentCollectedCubesListener);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAnyCurrentCollectedCubesListener;

    public static Entitas.IMatcher<GameEntity> AnyCurrentCollectedCubesListener {
        get {
            if (_matcherAnyCurrentCollectedCubesListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyCurrentCollectedCubesListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyCurrentCollectedCubesListener = matcher;
            }

            return _matcherAnyCurrentCollectedCubesListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddAnyCurrentCollectedCubesListener(IAnyCurrentCollectedCubesListener value) {
        var listeners = hasAnyCurrentCollectedCubesListener
            ? anyCurrentCollectedCubesListener.value
            : new System.Collections.Generic.List<IAnyCurrentCollectedCubesListener>();
        listeners.Add(value);
        ReplaceAnyCurrentCollectedCubesListener(listeners);
    }

    public void RemoveAnyCurrentCollectedCubesListener(IAnyCurrentCollectedCubesListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyCurrentCollectedCubesListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyCurrentCollectedCubesListener();
        } else {
            ReplaceAnyCurrentCollectedCubesListener(listeners);
        }
    }
}