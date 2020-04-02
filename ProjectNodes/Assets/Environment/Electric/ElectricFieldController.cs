using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElectricFieldController : MonoBehaviour
{
    public LayerMask electricLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        toUpdate();
    }

    void OnDrawGizmos()
    {
        toOnDrawGizmos();
    }

    public abstract void toUpdate();
    public abstract void toOnDrawGizmos();
    public abstract List<Collider2D> getCollidedElements();
    public abstract void activateParticleSystem();
    public abstract void deactivateParticleSystem();
}
