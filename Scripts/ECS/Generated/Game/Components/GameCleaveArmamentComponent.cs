//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCleaveArmament;

    public static Entitas.IMatcher<GameEntity> CleaveArmament {
        get {
            if (_matcherCleaveArmament == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CleaveArmament);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCleaveArmament = matcher;
            }

            return _matcherCleaveArmament;
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

    static readonly Game.Battle.CleaveArmamentComponent cleaveArmamentComponent = new Game.Battle.CleaveArmamentComponent();

    public bool isCleaveArmament {
        get { return HasComponent(GameComponentsLookup.CleaveArmament); }
        set {
            if (value != isCleaveArmament) {
                var index = GameComponentsLookup.CleaveArmament;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : cleaveArmamentComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
