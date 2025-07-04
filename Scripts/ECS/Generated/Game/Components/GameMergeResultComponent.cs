//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherMergeResult;

    public static Entitas.IMatcher<GameEntity> MergeResult {
        get {
            if (_matcherMergeResult == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.MergeResult);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherMergeResult = matcher;
            }

            return _matcherMergeResult;
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

    static readonly Game.Towers.MergeSpirits.Comps.MergeResultComponent mergeResultComponent = new Game.Towers.MergeSpirits.Comps.MergeResultComponent();

    public bool isMergeResult {
        get { return HasComponent(GameComponentsLookup.MergeResult); }
        set {
            if (value != isMergeResult) {
                var index = GameComponentsLookup.MergeResult;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : mergeResultComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
