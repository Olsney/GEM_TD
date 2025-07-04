//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherAttackSpeedAuraStatus;

    public static Entitas.IMatcher<GameEntity> AttackSpeedAuraStatus {
        get {
            if (_matcherAttackSpeedAuraStatus == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.AttackSpeedAuraStatus);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherAttackSpeedAuraStatus = matcher;
            }

            return _matcherAttackSpeedAuraStatus;
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

    static readonly Game.Battle.AttackSpeedAuraStatusComponent attackSpeedAuraStatusComponent = new Game.Battle.AttackSpeedAuraStatusComponent();

    public bool isAttackSpeedAuraStatus {
        get { return HasComponent(GameComponentsLookup.AttackSpeedAuraStatus); }
        set {
            if (value != isAttackSpeedAuraStatus) {
                var index = GameComponentsLookup.AttackSpeedAuraStatus;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : attackSpeedAuraStatusComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
