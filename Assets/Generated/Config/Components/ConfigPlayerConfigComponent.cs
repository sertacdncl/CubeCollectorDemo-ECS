//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class ConfigContext {

    public ConfigEntity playerConfigEntity { get { return GetGroup(ConfigMatcher.PlayerConfig).GetSingleEntity(); } }
    public PlayerConfigComponent playerConfig { get { return playerConfigEntity.playerConfig; } }
    public bool hasPlayerConfig { get { return playerConfigEntity != null; } }

    public ConfigEntity SetPlayerConfig(IPlayerConfig newValue) {
        if (hasPlayerConfig) {
            throw new Entitas.EntitasException("Could not set PlayerConfig!\n" + this + " already has an entity with PlayerConfigComponent!",
                "You should check if the context already has a playerConfigEntity before setting it or use context.ReplacePlayerConfig().");
        }
        var entity = CreateEntity();
        entity.AddPlayerConfig(newValue);
        return entity;
    }

    public void ReplacePlayerConfig(IPlayerConfig newValue) {
        var entity = playerConfigEntity;
        if (entity == null) {
            entity = SetPlayerConfig(newValue);
        } else {
            entity.ReplacePlayerConfig(newValue);
        }
    }

    public void RemovePlayerConfig() {
        playerConfigEntity.Destroy();
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
public partial class ConfigEntity {

    public PlayerConfigComponent playerConfig { get { return (PlayerConfigComponent)GetComponent(ConfigComponentsLookup.PlayerConfig); } }
    public bool hasPlayerConfig { get { return HasComponent(ConfigComponentsLookup.PlayerConfig); } }

    public void AddPlayerConfig(IPlayerConfig newValue) {
        var index = ConfigComponentsLookup.PlayerConfig;
        var component = (PlayerConfigComponent)CreateComponent(index, typeof(PlayerConfigComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePlayerConfig(IPlayerConfig newValue) {
        var index = ConfigComponentsLookup.PlayerConfig;
        var component = (PlayerConfigComponent)CreateComponent(index, typeof(PlayerConfigComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePlayerConfig() {
        RemoveComponent(ConfigComponentsLookup.PlayerConfig);
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
public sealed partial class ConfigMatcher {

    static Entitas.IMatcher<ConfigEntity> _matcherPlayerConfig;

    public static Entitas.IMatcher<ConfigEntity> PlayerConfig {
        get {
            if (_matcherPlayerConfig == null) {
                var matcher = (Entitas.Matcher<ConfigEntity>)Entitas.Matcher<ConfigEntity>.AllOf(ConfigComponentsLookup.PlayerConfig);
                matcher.componentNames = ConfigComponentsLookup.componentNames;
                _matcherPlayerConfig = matcher;
            }

            return _matcherPlayerConfig;
        }
    }
}
