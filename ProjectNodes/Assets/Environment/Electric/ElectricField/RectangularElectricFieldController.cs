using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectangularElectricFieldController : ElectricFieldController
{
    public BoxCollider2D colliderElectricRange;

    public override void toUpdate()
    {
    }

    public override void toOnDrawGizmos()
    {
    }

    public override void activateParticleSystem()
    {
    }

    public override void deactivateParticleSystem()
    {
    }

    public override List<Collider2D> getCollidedElements()
    {
        List<Collider2D> colliders = new List<Collider2D>();
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(base.electricLayer);
        contactFilter.useTriggers = true;

        Physics2D.OverlapCollider(colliderElectricRange, contactFilter, colliders);

        return colliders;
    }
}
