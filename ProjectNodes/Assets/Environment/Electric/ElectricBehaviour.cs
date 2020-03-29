using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricBehaviour : MonoBehaviour
{
    public bool isOn;
    public bool alwaysOn;
    public float electricFieldRange;
    public LayerMask electricLayer;
    public CircleCollider2D circleCollider;

    // Start is called before the first frame update
    void Start()
    {
        setUp();
    }

    void OnValidate()
    {
        setUp();
    }

    public void setUp()
    {
        circleCollider.radius = electricFieldRange;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, electricFieldRange);
    }
}
