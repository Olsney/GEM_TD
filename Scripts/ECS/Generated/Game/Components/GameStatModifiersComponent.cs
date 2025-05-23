//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherStatModifiers;

    public static Entitas.IMatcher<GameEntity> StatModifiers {
        get {
            if (_matcherStatModifiers == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.StatModifiers);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherStatModifiers = matcher;
            }

            return _matcherStatModifiers;
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
public partial class GameEntity {

    public Game.Battle.StatModifiersComponent statModifiers { get { return (Game.Battle.StatModifiersComponent)GetComponent(GameComponentsLookup.StatModifiers); } }
    public System.Collections.Generic.Dictionary<Game.Battle.StatEnum, float> StatModifiers { get { return statModifiers.Value; } }
    public bool hasStatModifiers { get { return HasComponent(GameComponentsLookup.StatModifiers); } }

    public GameEntity AddStatModifiers(System.Collections.Generic.Dictionary<Game.Battle.StatEnum, float> newValue) {
        var index = GameComponentsLookup.StatModifiers;
        var component = (Game.Battle.StatModifiersComponent)CreateComponent(index, typeof(Game.Battle.StatModifiersComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceStatModifiers(System.Collections.Generic.Dictionary<Game.Battle.StatEnum, float> newValue) {
        var index = GameComponentsLookup.StatModifiers;
        var component = (Game.Battle.StatModifiersComponent)CreateComponent(index, typeof(Game.Battle.StatModifiersComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveStatModifiers() {
        RemoveComponent(GameComponentsLookup.StatModifiers);
        return this;
    }
}
