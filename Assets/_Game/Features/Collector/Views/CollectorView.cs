using Entitas;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CollectorView : View
{
    [SerializeField] private Rigidbody rigidBody;
    public override void Link(Contexts contexts,IEntity entity)
    {
        base.Link(contexts,entity);
        Contexts.sharedInstance.game.ReplacePlayerRigidbody(rigidBody);
    }


    public void OnPlayerMoveData(GameEntity entity, Vector3 velocity, Quaternion rotation)
    {
        rigidBody.velocity = velocity;

        if(rotation != Quaternion.identity)
            transform.rotation = rotation;
    }
}
