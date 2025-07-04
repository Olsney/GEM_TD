//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEAura1Status;

    public static Entitas.IMatcher<GameEntity> EAura1Status {
        get {
            if (_matcherEAura1Status == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EAura1Status);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEAura1Status = matcher;
            }

            return _matcherEAura1Status;
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

    static readonly Game.Battle.EAura1StatusComponent eAura1StatusComponent = new Game.Battle.EAura1StatusComponent();

    public bool isEAura1Status {
        get { return HasComponent(GameComponentsLookup.EAura1Status); }
        set {
            if (value != isEAura1Status) {
                var index = GameComponentsLookup.EAura1Status;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : eAura1StatusComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
