using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PurpleNodeElectricBehaviour : ElectricBehaviour
{
    [Header("Purple Node")]
    public PurpleNodeElectricBehaviour otherPurpleNode;
    public float maxRangeConnection;

    public override void toStart()
    {
    }

    public override void toUpdate()
    {
    }

    public override void toOnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, maxRangeConnection);
    }

    public override Collider2D[] getCollidedElements()
    {
        Collider2D[] colliders2D = Physics2D.OverlapCircleAll(base.transform.position, base.electricFieldRange, base.electricLayer);
        if(Vector3.Distance(transform.position, otherPurpleNode.transform.position) <= (maxRangeConnection + otherPurpleNode.maxRangeConnection))
        {
            colliders2D = colliders2D.Concat(Physics2D.OverlapCircleAll(otherPurpleNode.transform.position, otherPurpleNode.electricFieldRange, otherPurpleNode.electricLayer)).ToArray();
        }
        return colliders2D;
    }

    public override List<ElectricBehaviour> handleActivate()
    {
        base.isOn = true;
        List<ElectricBehaviour> electricElements = new List<ElectricBehaviour>();
        electricElements.Add(this);

        if(Vector3.Distance(transform.position, otherPurpleNode.transform.position) <= (maxRangeConnection + otherPurpleNode.maxRangeConnection))
        {
            otherPurpleNode.isOn = true;
            electricElements.Add(otherPurpleNode);
        }

        return electricElements;
    }

    public override void handleDeactivate()
    {
        base.isOn = false;
    }
}
