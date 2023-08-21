using System.Collections.Generic;
using Entitas;

public sealed class PlayerMoveSystem : ReactiveSystem<GameEntity>
{
    readonly Contexts _contexts;

    public PlayerMoveSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
        context.CreateCollector(GameMatcher.PlayerMoveData.Added());

    protected override bool Filter(GameEntity entity) => _contexts.game.hasPlayerMoveData;

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            var playerMoveData = e.playerMoveData;
            var rigidbody = _contexts.game.playerRigidbody.Value;
            rigidbody.velocity = playerMoveData.Velocity;
            var rotation = playerMoveData.Rotation;
            var playerGroup = _contexts.game.GetGroup(GameMatcher.Player);
            foreach (var player in playerGroup)
            {
                if (rotation != UnityEngine.Quaternion.identity)
                    player.ReplaceQuaternionRotation(rotation);
            }
        }
    }
}
