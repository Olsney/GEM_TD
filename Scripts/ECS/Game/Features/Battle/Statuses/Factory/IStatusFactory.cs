namespace Game.Battle
{
    public interface IStatusFactory
    {
        GameEntity CreateStatus(StatusSetup setup, int producerId, int targetId);
    }
}