using System;
using Entitas;
using Entitas.Unity;
using UnityEngine;

public class MagneticFieldView : View
{

    public override void Link(Contexts contexts,IEntity entity)
    {
        base.Link(contexts,entity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            var collidedObject = other.gameObject;
            var link = _linkedEntity;
            var targetLink = collidedObject.gameObject.GetEntityLink();

            _contexts.game.CreateEntity().AddTrigger(link, (GameEntity)targetLink.entity, gameObject,collidedObject);
        }
    }
}
