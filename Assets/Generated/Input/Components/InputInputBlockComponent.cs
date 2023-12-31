//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity inputBlockEntity { get { return GetGroup(InputMatcher.InputBlock).GetSingleEntity(); } }

    public bool isInputBlock {
        get { return inputBlockEntity != null; }
        set {
            var entity = inputBlockEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isInputBlock = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly InputBlock inputBlockComponent = new InputBlock();

    public bool isInputBlock {
        get { return HasComponent(InputComponentsLookup.InputBlock); }
        set {
            if (value != isInputBlock) {
                var index = InputComponentsLookup.InputBlock;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : inputBlockComponent;

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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherInputBlock;

    public static Entitas.IMatcher<InputEntity> InputBlock {
        get {
            if (_matcherInputBlock == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputBlock);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputBlock = matcher;
            }

            return _matcherInputBlock;
        }
    }
}
