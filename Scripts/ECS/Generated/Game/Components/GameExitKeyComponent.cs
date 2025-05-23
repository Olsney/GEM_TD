//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherExitKey;

    public static Entitas.IMatcher<GameEntity> ExitKey {
        get {
            if (_matcherExitKey == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ExitKey);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherExitKey = matcher;
            }

            return _matcherExitKey;
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

    static readonly Game.Inputs.ExitKeyComponent exitKeyComponent = new Game.Inputs.ExitKeyComponent();

    public bool isExitKey {
        get { return HasComponent(GameComponentsLookup.ExitKey); }
        set {
            if (value != isExitKey) {
                var index = GameComponentsLookup.ExitKey;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : exitKeyComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
