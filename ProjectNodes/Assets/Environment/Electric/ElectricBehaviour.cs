using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElectricBehaviour : MonoBehaviour
{
    public bool isOn;
    public bool alwaysOn;

    [Header("Electric Field")]
    public ElectricFieldController electricFieldController;

    // Start is called before the first frame update
    void Start()
    {
        toStart();
    }

    void Update()
    {
        Debug.Log("sirve");
        toUpdate();
    }

    void OnDrawGizmos()
    {
        toOnDrawGizmos();
    }

    public void activateParticleSystem()
    {
        electricFieldController.activateParticleSystem();
    }

    public void deactivateParticleSystem()
    {
        electricFieldController.deactivateParticleSystem();
    }

    public abstract void toStart();
    public abstract void toUpdate();
    public abstract void toOnDrawGizmos();

    public abstract List<ElectricBehaviour> getCollidedElements();
    public abstract List<ElectricBehaviour> handleActivate();
    public abstract void handleDeactivate();
}
