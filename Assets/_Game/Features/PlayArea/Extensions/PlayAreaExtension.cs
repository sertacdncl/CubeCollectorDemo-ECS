using UnityEngine;

namespace Game
{
    public static class PlayAreaExtension
    {
        public static GameEntity CreatePixelCube(this GameContext context, Vector2Int pos, Color color)
        {
            var entity = context.CreateEntity();
            entity.AddAsset("ColoredCube");
            entity.AddPosition(pos.ToViewPosition());
            entity.AddColor(color);
            entity.isColoredCube = true;
            return entity;
        }

        public static GameEntity CreateMagneticField(this GameContext context, Vector3 pos)
        {
            var entity = context.CreateEntity();
            entity.AddAsset("MagneticFieldView");
            entity.AddPosition(pos);
            return entity;
        }
    }
}
