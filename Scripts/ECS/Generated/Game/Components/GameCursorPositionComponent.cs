//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCursorPosition;

    public static Entitas.IMatcher<GameEntity> CursorPosition {
        get {
            if (_matcherCursorPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CursorPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCursorPosition = matcher;
            }

            return _matcherCursorPosition;
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

    public Game.Cursor.CursorPositionComponent cursorPosition { get { return (Game.Cursor.CursorPositionComponent)GetComponent(GameComponentsLookup.CursorPosition); } }
    public UnityEngine.Vector2 CursorPosition { get { return cursorPosition.Value; } }
    public bool hasCursorPosition { get { return HasComponent(GameComponentsLookup.CursorPosition); } }

    public GameEntity AddCursorPosition(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.CursorPosition;
        var component = (Game.Cursor.CursorPositionComponent)CreateComponent(index, typeof(Game.Cursor.CursorPositionComponent));
        component.Value = newValue;
        AddComponent(index, component);
        return this;
    }

    public GameEntity ReplaceCursorPosition(UnityEngine.Vector2 newValue) {
        var index = GameComponentsLookup.CursorPosition;
        var component = (Game.Cursor.CursorPositionComponent)CreateComponent(index, typeof(Game.Cursor.CursorPositionComponent));
        component.Value = newValue;
        ReplaceComponent(index, component);
        return this;
    }

    public GameEntity RemoveCursorPosition() {
        RemoveComponent(GameComponentsLookup.CursorPosition);
        return this;
    }
}
