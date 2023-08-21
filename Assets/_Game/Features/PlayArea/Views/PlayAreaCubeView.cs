using Entitas;
using UnityEngine;

public class PlayAreaCubeView : View
    , IColorListener
    , IAnyPlayAreaParentListener
    , IRigidbodyListener
    , IColliderListener
{
    [SerializeField] private new MeshRenderer renderer;
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private new Collider collider;
    public override void Link(Contexts contexts,IEntity entity)
    {
        base.Link(contexts,entity);
        _linkedEntity.AddColorListener(this);
        _linkedEntity.AddAnyPlayAreaParentListener(this);
        _linkedEntity.AddRigidbodyListener(this);
        _linkedEntity.AddColliderListener(this);
    }

    public void OnColor(GameEntity entity, Color value)
    {
        renderer.material.color = value;
    }

    public void OnAnyPlayAreaParent(GameEntity entity, Transform value)
    {
        transform.SetParent(value, false);
    }

    public void OnRigidbody(GameEntity entity, bool isKinematic, Vector3 velocity)
    {
        rigidbody.isKinematic = isKinematic;
        rigidbody.velocity = velocity;
    }

    public void OnCollider(GameEntity entity, bool isEnabled, bool isTrigger)
    {
        collider.enabled = isEnabled;
        collider.isTrigger = isTrigger;
    }
}
