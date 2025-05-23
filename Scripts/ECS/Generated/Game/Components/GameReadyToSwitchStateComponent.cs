//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherReadyToSwitchState;

    public static Entitas.IMatcher<GameEntity> ReadyToSwitchState {
        get {
            if (_matcherReadyToSwitchState == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ReadyToSwitchState);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReadyToSwitchState = matcher;
            }

            return _matcherReadyToSwitchState;
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

    static readonly Game.ReadyToSwitchStateComponent readyToSwitchStateComponent = new Game.ReadyToSwitchStateComponent();

    public bool isReadyToSwitchState {
        get { return HasComponent(GameComponentsLookup.ReadyToSwitchState); }
        set {
            if (value != isReadyToSwitchState) {
                var index = GameComponentsLookup.ReadyToSwitchState;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : readyToSwitchStateComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
