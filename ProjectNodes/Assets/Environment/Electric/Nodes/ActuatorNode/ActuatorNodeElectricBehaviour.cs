using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActuatorNodeElectricBehaviour : ElectricBehaviour
{

    public override void toStart()
    {
    }

    public override void toUpdate()
    {
    }

    public override void toOnDrawGizmos()
    {
    }

    public override List<ElectricBehaviour> getCollidedElements()
    {
        List<ElectricBehaviour> electricBehaviourList = new List<ElectricBehaviour>();
        List<Collider2D> colliders = base.electricFieldController.getCollidedElements();

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

        base.activateParticleSystem();

        return electricElements;
    }

    public override void handleDeactivate()
    {
        base.isOn = false;
        base.deactivateParticleSystem();
    }
}
