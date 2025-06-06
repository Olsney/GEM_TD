//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherEnemyFragCreated;

    public static Entitas.IMatcher<GameEntity> EnemyFragCreated {
        get {
            if (_matcherEnemyFragCreated == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.EnemyFragCreated);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherEnemyFragCreated = matcher;
            }

            return _matcherEnemyFragCreated;
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

    static readonly Game.Enemies.EnemyFragCreatedComponent enemyFragCreatedComponent = new Game.Enemies.EnemyFragCreatedComponent();

    public bool isEnemyFragCreated {
        get { return HasComponent(GameComponentsLookup.EnemyFragCreated); }
        set {
            if (value != isEnemyFragCreated) {
                var index = GameComponentsLookup.EnemyFragCreated;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : enemyFragCreatedComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
