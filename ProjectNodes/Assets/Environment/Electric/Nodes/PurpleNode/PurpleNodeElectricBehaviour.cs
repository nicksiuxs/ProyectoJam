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

    public override List<ElectricBehaviour> getCollidedElements()
    {
        List<Collider2D> colliders = base.electricFieldController.getCollidedElements();
        if(Vector3.Distance(transform.position, otherPurpleNode.transform.position) <= (maxRangeConnection + otherPurpleNode.maxRangeConnection))
        {
            colliders = colliders.Concat(otherPurpleNode.electricFieldController.getCollidedElements()).ToList();
        }
        
        List<ElectricBehaviour> electricBehaviourList = new List<ElectricBehaviour>();

        foreach(Collider2D collider in colliders)
        {
            electricBehaviourList.Add(collider.GetComponentInParent<ElectricBehaviour>());
        }

        return electricBehaviourList;
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

            otherPurpleNode.activateParticleSystem();
        }

        base.activateParticleSystem();

        return electricElements;
    }

    public override void handleDeactivate()
    {
        base.isOn = false;
        base.deactivateParticleSystem();
    }
}
