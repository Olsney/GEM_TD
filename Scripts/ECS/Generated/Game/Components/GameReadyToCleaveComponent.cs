//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherReadyToCleave;

    public static Entitas.IMatcher<GameEntity> ReadyToCleave {
        get {
            if (_matcherReadyToCleave == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ReadyToCleave);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherReadyToCleave = matcher;
            }

            return _matcherReadyToCleave;
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

    static readonly Game.Battle.CleaveAbility.Comps.ReadyToCleaveComponent readyToCleaveComponent = new Game.Battle.CleaveAbility.Comps.ReadyToCleaveComponent();

    public bool isReadyToCleave {
        get { return HasComponent(GameComponentsLookup.ReadyToCleave); }
        set {
            if (value != isReadyToCleave) {
                var index = GameComponentsLookup.ReadyToCleave;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : readyToCleaveComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
