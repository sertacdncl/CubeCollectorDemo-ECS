using System.Collections.Generic;
using DG.Tweening;
using Entitas;
using UnityEngine;

public sealed class MagneticFieldSystem : ReactiveSystem<GameEntity>
{
    readonly Contexts _contexts;

    public MagneticFieldSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
        context.CreateCollector(GameMatcher.Trigger.Added());

    protected override bool Filter(GameEntity entity) => !entity.trigger.Other.isFlying && !entity.trigger.Other.isDestroyed;

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if(e.trigger.Other.isDestroyed || e.trigger.Other.isFlying) continue;
            var baseEntity = e.trigger.Other;
            var baseObject = e.trigger.OtherView;
            var targetObject = e.trigger.SelfView;

            baseEntity.isFlying = true;
            baseEntity.ReplaceCollider(false,true);
            baseEntity.ReplaceRigidbody(true,Vector3.zero);

            var startPos = baseObject.transform.position;
            var targetPos = targetObject.transform.position;
            var distance = Vector3.Distance(startPos, targetPos);
            var maxDistance = Vector3.one * (0.5f * distance);
            var tangentPos = startPos - maxDistance;


            var collectedCubes = _contexts.game.hasCurrentCollectedCubes
                ? _contexts.game.currentCollectedCubes.Value
                : 0;

            _contexts.game.ReplaceCurrentCollectedCubes(collectedCubes + 1);

            DOVirtual.Float(0f, 1f, .5f, value =>
            {
                baseObject.transform.position = Bezier.GetPoint(startPos, tangentPos, targetPos, value);
                baseEntity.ReplaceScale(Vector3.one * 1.25f * (1 + Mathf.Sin(Mathf.Deg2Rad * 180f * value)));
            }).SetEase(Ease.OutExpo).OnComplete(() =>
            {
                baseEntity.isDestroyed = true;
                baseEntity.isFlying = false;
            });

        }
    }
}
