//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRoundTimer;

    public static Entitas.IMatcher<GameEntity> RoundTimer {
        get {
            if (_matcherRoundTimer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RoundTimer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRoundTimer = matcher;
            }

            return _matcherRoundTimer;
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

    public Game.RoundTimerComponent roundTimer { get { return (Game.RoundTimerComponent)GetComponent(GameComponentsLookup.RoundTimer); } }
    public float RoundTimer { get { return roundTimer.Value; } }
    public bool hasRoundTimer { get { return HasComponent(GameComponentsLookup.RoundTimer); } }

    public GameEntity AddRoundTimer(float newValue) {
        var index = GameComponentsLookup.RoundTimer;
        var component = (Game.RoundTimerComponent)CreateComponent(index, typeof(Game.RoundTimerComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceRoundTimer(float newValue) {
        var index = GameComponentsLookup.RoundTimer;
        var component = (Game.RoundTimerComponent)CreateComponent(index, typeof(Game.RoundTimerComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveRoundTimer() {
        RemoveComponent(GameComponentsLookup.RoundTimer);
        return this;
    }
}
