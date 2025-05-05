using System.Collections.Generic;
using System;
using Game;
using Game.Battle;
using Game.Battle.Configs;
using Game.Enemies;
using Game.Entity;
using Game.Extensions;
using Game.View;
using Services.AssetProviders;
using Services.Identifiers;
using Services.ProjectData;
using Services.StaticData;
using UnityEngine;

public class GameEntityFactories
{
    private readonly IIdentifierService _identifierService;
    private readonly IAssetProvider _assetProvider;
    private readonly IStaticDataService _staticDataService;
    private readonly GameContext _game;
    private readonly IProjectDataService _projectDataService;

    public GameEntityFactories(
        IIdentifierService identifierService,
        IAssetProvider assetProvider,
        IStaticDataService staticDataService,
        GameContext game,
        IProjectDataService projectDataService
    )
    {
        _identifierService = identifierService;
        _assetProvider = assetProvider;
        _staticDataService = staticDataService;
        _game = game;
        _projectDataService = projectDataService;
    }

    public void CreateCursor()
    {
        CreateGameEntity
            .Empty()
            .AddCursorPosition(Vector2.zero)
            .AddId(_identifierService.Next())
            .With(x => x.isCursor = true)
            ;
    }

    public void CreateStartPoint(
        int positionX,
        int positionY,
        int playerId,
        bool isHuman
    )
    {
        CreateGameEntity
            .Empty()
            .AddId(_identifierService.Next())
            .AddPrefab(_assetProvider.LoadAsset("CheckPoint").GetComponent<GameEntityView>())
            .AddWorldPosition(new Vector3(positionX, 0, positionY))
            .AddPlayerId(playerId)
            .With(x => x.isStartPoint = true)
            .With(x => x.isCanRaycast = true)
            .With(x => x.isHuman = isHuman)
            ;
    }

    public void CreateFinishPoint(
        int positionX,
        int positionY,
        int playerId,
        bool isHuman
    )
    {
        CreateGameEntity
            .Empty()
            .AddId(_identifierService.Next())
            .AddPrefab(_assetProvider.LoadAsset("CheckPoint").GetComponent<GameEntityView>())
            .AddWorldPosition(new Vector3(positionX, 0, positionY))
            .AddPlayerId(playerId)
            .With(x => x.isFinishPoint = true)
            .With(x => x.isCanRaycast = true)
            .With(x => x.isHuman = isHuman)
            ;
    }

    public void CreateCheckpoint(
        int positionX,
        int positionY,
        int number,
        int playerId,
        bool isHuman
    )
    {
        CreateGameEntity
            .Empty()
            .AddId(_identifierService.Next())
            .AddPrefab(_assetProvider.LoadAsset("CheckPoint").GetComponent<GameEntityView>())
            .AddWorldPosition(new Vector3(positionX, 0, positionY))
            .AddCheckPoint(number)
            .AddPlayerId(playerId)
            .With(x => x.isCanRaycast = true)
            .With(x => x.isHuman = isHuman)
            ;
    }

    public void CreateWall(
        int worldPositionX,
        int worldPositionY,
        int mazePositionX,
        int mazePositionY,
        int playerId
    )
    {
        float length = _projectDataService.CurrentMazeData.Height;
        float width = _projectDataService.CurrentMazeData.Width;

        int centerX = (int)(length / 2 + 0.5f);
        int centerY = (int)(width / 2 + 0.5f);

        float distanceToCenter =
            Vector2.Distance(new Vector2(mazePositionX, mazePositionY), new Vector2(centerX, centerY));

        CreateGameEntity
            .Empty()
            .AddId(_identifierService.Next())
            .AddPrefab(_assetProvider.LoadAsset("Wall").GetComponent<GameEntityView>())
            .AddWorldPosition(new Vector3(worldPositionX, 0, worldPositionY))
            .AddMazePosition(new Vector2Int(mazePositionX, mazePositionY))
            .AddPlayerId(playerId)
            .AddDistanceToCenter(distanceToCenter)
            .With(x => x.isWall = true)
            .With(x => x.isCanRaycast = true)
            ;
    }

    public void CreateEnemy(
        Vector2Int position,
        int round,
        int playerId,
        bool isHuman
    )
    {
        EnemyConfig config = _staticDataService.GetEnemyConfig(round);

        Dictionary<StatEnum, float> baseStats = InitStats.EmptyStatDictionary()
            .With(x => x[StatEnum.MoveSpeed] = config.MoveSpeed)
            .With(x => x[StatEnum.MaxHeathPoints] = config.MaxHealthPoints)
            .With(x => x[StatEnum.RotationSpeed] = 10f)
            .With(x => x[StatEnum.Armor] = 10f)
            ;

        CreateGameEntity
            .Empty()
            .AddId(_identifierService.Next())
            .AddPrefab(config.Prefab)
            .AddStatModifiers(InitStats.EmptyStatDictionary())
            .AddBaseStats(baseStats)
            .AddWorldPosition(new Vector3(position.x, 0, position.y))
            .AddRotation(default)
            .AddDirection(default)
            .AddMoveSpeed(baseStats[StatEnum.MoveSpeed])
            .AddTargetPlaceIndex(0)
            .AddPathNumber(0)
            .AddCurrentHealthPoints(baseStats[StatEnum.MaxHeathPoints])
            .AddMaxHealthPoints(baseStats[StatEnum.MaxHeathPoints])
            .AddArmor(baseStats[StatEnum.Armor])
            .AddRotationSpeed(baseStats[StatEnum.RotationSpeed])
            .AddRound(round)
            .AddPlayerId(playerId)
            .AddAge(0)
            .With(x => x.isCanRaycast = true)
            .With(x => x.isEnemy = true)
            .With(x => x.isTarget = true)
            .With(x => x.isTurnedAlongDirection = true)
            .With(x => x.isMovementAvailable = true)
            .With(x => x.isHuman = isHuman, when: isHuman);
    }

    public GameEntity CreatePlayer(bool isHuman, int index)
    {
        var player = CreateGameEntity
            .Empty()
            .AddId(_identifierService.Next())
            .AddGameLoopStateEnum(GameLoopStateEnum.PlayerAbility)
            .AddSpiritPlaced(0)
            .AddLevel(3)
            .AddRound(1)
            .AddCurrentHealthPoints(100)
            .AddTotalGameTime(0)
            .AddRoundTimer(0)
            .AddIndex(index)
            .With(x => x.isPlayer = true)
            .With(x => x.isHuman = true, when: isHuman)
            ;
        
        return player;
    }

    public void CreateMainEntity()
    {
        CreateGameEntity
            .Empty()
            .AddId(_identifierService.Next())
            .AddEnemySpawned(0)
            .AddRound(0)
            .With(x => x.isGameMain = true)
            ;
    }

    public void CreateRoundComplete(
        int playerId,
        int spawnerRound,
        int maxEnemies
    )
    {
        CreateGameEntity
            .Empty()
            .AddId(_identifierService.Next())
            .AddPlayerId(playerId)
            .AddEnemiesKilled(0)
            .AddEnemiesPerRound(maxEnemies)
            .AddRound(spawnerRound)
            .With(x => x.isRoundComplete = true)
            ;
    }

    public void CreateExplosionVisualEffect(
        Vector3 position,
        int producerId
    )
    {
        var entity = _game.GetEntityWithId(producerId);
        AbilitySetup setup = _staticDataService.GetTowerConfig(entity.TowerEnum).BasicAttackSetup;

        CreateGameEntity
            .Empty()
            .AddId(_identifierService.Next())
            .AddPrefab(setup.ExplosionPrefab)
            .AddWorldPosition(position)
            .AddSelfDestructTimer(2f)
            ;
    }

    public void CreateMuzzleFlashEffect(
        Vector3 position,
        Quaternion rotation,
        int producerId
    )
    {
        var entity = _game.GetEntityWithId(producerId);
        AbilitySetup setup = _staticDataService.GetTowerConfig(entity.TowerEnum).BasicAttackSetup;

        CreateGameEntity
            .Empty()
            .AddId(_identifierService.Next())
            .AddPrefab(setup.MuzzleFlashPrefab)
            .AddWorldPosition(position)
            .AddRotation(rotation)
            .AddSelfDestructTimer(2f)
            ;
    }
}