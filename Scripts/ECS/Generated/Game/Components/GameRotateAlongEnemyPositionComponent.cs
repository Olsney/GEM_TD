//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRotateAlongEnemyPosition;

    public static Entitas.IMatcher<GameEntity> RotateAlongEnemyPosition {
        get {
            if (_matcherRotateAlongEnemyPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RotateAlongEnemyPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRotateAlongEnemyPosition = matcher;
            }

            return _matcherRotateAlongEnemyPosition;
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

    static readonly Game.Towers.RotateAlongEnemyPositionComponent rotateAlongEnemyPositionComponent = new Game.Towers.RotateAlongEnemyPositionComponent();

    public bool isRotateAlongEnemyPosition {
        get { return HasComponent(GameComponentsLookup.RotateAlongEnemyPosition); }
        set {
            if (value != isRotateAlongEnemyPosition) {
                var index = GameComponentsLookup.RotateAlongEnemyPosition;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : rotateAlongEnemyPositionComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}
