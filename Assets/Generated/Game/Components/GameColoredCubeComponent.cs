//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly ColoredCubeComponent coloredCubeComponent = new ColoredCubeComponent();

    public bool isColoredCube {
        get { return HasComponent(GameComponentsLookup.ColoredCube); }
        set {
            if (value != isColoredCube) {
                var index = GameComponentsLookup.ColoredCube;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : coloredCubeComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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

    static Entitas.IMatcher<GameEntity> _matcherColoredCube;

    public static Entitas.IMatcher<GameEntity> ColoredCube {
        get {
            if (_matcherColoredCube == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ColoredCube);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherColoredCube = matcher;
            }

            return _matcherColoredCube;
        }
    }
}