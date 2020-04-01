using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceNodeElectricBehaviour : ElectricBehaviour
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

    public override List<Collider2D> getCollidedElements()
    {
        return base.electricFieldController.getCollidedElements();
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
