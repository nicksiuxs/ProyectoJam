using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public abstract class ElectricBehaviour : MonoBehaviour
{
    public bool isOn;
    public bool alwaysOn;
    public float electricFieldRange;
    public LayerMask electricLayer;
    public CircleCollider2D circleCollider;

    [Header("Range Circle")]
    public ElectricFieldController electricFieldController;

    // Start is called before the first frame update
    void Start()
    {
        setUp();
        toStart();
    }

    void OnValidate()
    {
        setUp();
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

    public void setUp()
    {
        circleCollider.radius = electricFieldRange;
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

    public abstract List<Collider2D> getCollidedElements();
    public abstract List<ElectricBehaviour> handleActivate();
    public abstract void handleDeactivate();
}
