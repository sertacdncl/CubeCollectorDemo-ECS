//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameContext {

    public GameEntity playerRigidbodyEntity { get { return GetGroup(GameMatcher.PlayerRigidbody).GetSingleEntity(); } }
    public PlayerRigidbody playerRigidbody { get { return playerRigidbodyEntity.playerRigidbody; } }
    public bool hasPlayerRigidbody { get { return playerRigidbodyEntity != null; } }

    public GameEntity SetPlayerRigidbody(UnityEngine.Rigidbody newValue) {
        if (hasPlayerRigidbody) {
            throw new Entitas.EntitasException("Could not set PlayerRigidbody!\n" + this + " already has an entity with PlayerRigidbody!",
                "You should check if the context already has a playerRigidbodyEntity before setting it or use context.ReplacePlayerRigidbody().");
        }
        var entity = CreateEntity();
        entity.AddPlayerRigidbody(newValue);
        return entity;
    }

    public void ReplacePlayerRigidbody(UnityEngine.Rigidbody newValue) {
        var entity = playerRigidbodyEntity;
        if (entity == null) {
            entity = SetPlayerRigidbody(newValue);
        } else {
            entity.ReplacePlayerRigidbody(newValue);
        }
    }

    public void RemovePlayerRigidbody() {
        playerRigidbodyEntity.Destroy();
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
public partial class GameEntity {

    public PlayerRigidbody playerRigidbody { get { return (PlayerRigidbody)GetComponent(GameComponentsLookup.PlayerRigidbody); } }
    public bool hasPlayerRigidbody { get { return HasComponent(GameComponentsLookup.PlayerRigidbody); } }

    public void AddPlayerRigidbody(UnityEngine.Rigidbody newValue) {
        var index = GameComponentsLookup.PlayerRigidbody;
        var component = (PlayerRigidbody)CreateComponent(index, typeof(PlayerRigidbody));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePlayerRigidbody(UnityEngine.Rigidbody newValue) {
        var index = GameComponentsLookup.PlayerRigidbody;
        var component = (PlayerRigidbody)CreateComponent(index, typeof(PlayerRigidbody));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerRigidbody() {
        RemoveComponent(GameComponentsLookup.PlayerRigidbody);
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

    static Entitas.IMatcher<GameEntity> _matcherPlayerRigidbody;

    public static Entitas.IMatcher<GameEntity> PlayerRigidbody {
        get {
            if (_matcherPlayerRigidbody == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.PlayerRigidbody);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPlayerRigidbody = matcher;
            }

            return _matcherPlayerRigidbody;
        }
    }
}
