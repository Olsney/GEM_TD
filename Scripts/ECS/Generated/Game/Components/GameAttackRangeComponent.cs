//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAttackRange;

    public static Entitas.IMatcher<GameEntity> AttackRange {
        get {
            if (_matcherAttackRange == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AttackRange);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAttackRange = matcher;
            }

            return _matcherAttackRange;
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

    public Game.Towers.AttackRangeComponent attackRange { get { return (Game.Towers.AttackRangeComponent)GetComponent(GameComponentsLookup.AttackRange); } }
    public float AttackRange { get { return attackRange.Value; } }
    public bool hasAttackRange { get { return HasComponent(GameComponentsLookup.AttackRange); } }

    public GameEntity AddAttackRange(float newValue) {
        var index = GameComponentsLookup.AttackRange;
        var component = (Game.Towers.AttackRangeComponent)CreateComponent(index, typeof(Game.Towers.AttackRangeComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceAttackRange(float newValue) {
        var index = GameComponentsLookup.AttackRange;
        var component = (Game.Towers.AttackRangeComponent)CreateComponent(index, typeof(Game.Towers.AttackRangeComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveAttackRange() {
        RemoveComponent(GameComponentsLookup.AttackRange);
        return this;
    }
}
