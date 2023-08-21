using UnityEngine;

namespace Game
{
    public static class CollectorExtension
    {
        public static GameEntity CreatePlayer(this GameContext context, Vector3 pos)
        {
            var entity = context.CreateEntity();
            entity.AddAsset("Collector");
            entity.AddPosition(pos);
            entity.isCollector = true;
            entity.isPlayer = true;
            return entity;
        }
    }
}
