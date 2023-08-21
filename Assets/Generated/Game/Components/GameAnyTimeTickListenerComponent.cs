//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public AnyTimeTickListenerComponent anyTimeTickListener { get { return (AnyTimeTickListenerComponent)GetComponent(GameComponentsLookup.AnyTimeTickListener); } }
    public bool hasAnyTimeTickListener { get { return HasComponent(GameComponentsLookup.AnyTimeTickListener); } }

    public void AddAnyTimeTickListener(System.Collections.Generic.List<IAnyTimeTickListener> newValue) {
        var index = GameComponentsLookup.AnyTimeTickListener;
        var component = (AnyTimeTickListenerComponent)CreateComponent(index, typeof(AnyTimeTickListenerComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAnyTimeTickListener(System.Collections.Generic.List<IAnyTimeTickListener> newValue) {
        var index = GameComponentsLookup.AnyTimeTickListener;
        var component = (AnyTimeTickListenerComponent)CreateComponent(index, typeof(AnyTimeTickListenerComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAnyTimeTickListener() {
        RemoveComponent(GameComponentsLookup.AnyTimeTickListener);
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

    static Entitas.IMatcher<GameEntity> _matcherAnyTimeTickListener;

    public static Entitas.IMatcher<GameEntity> AnyTimeTickListener {
        get {
            if (_matcherAnyTimeTickListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AnyTimeTickListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAnyTimeTickListener = matcher;
            }

            return _matcherAnyTimeTickListener;
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

    public void AddAnyTimeTickListener(IAnyTimeTickListener value) {
        var listeners = hasAnyTimeTickListener
            ? anyTimeTickListener.value
            : new System.Collections.Generic.List<IAnyTimeTickListener>();
        listeners.Add(value);
        ReplaceAnyTimeTickListener(listeners);
    }

    public void RemoveAnyTimeTickListener(IAnyTimeTickListener value, bool removeComponentWhenEmpty = true) {
        var listeners = anyTimeTickListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveAnyTimeTickListener();
        } else {
            ReplaceAnyTimeTickListener(listeners);
        }
    }
}