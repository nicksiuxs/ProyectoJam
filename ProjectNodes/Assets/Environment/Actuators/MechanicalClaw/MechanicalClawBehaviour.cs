using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechanicalClawBehaviour : MonoBehaviour
{
    public List<ActuatorNodeElectricBehaviour> actuatorNodes;
    public bool isOpen = false;
    public GameObject releaseObject;

    private Transform otherParent;
    private Rigidbody2D rigidbodyOther;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyOther = releaseObject.GetComponent<Rigidbody2D>();
        otherParent = rigidbodyOther.transform.parent;

        rigidbodyOther.isKinematic = true;
        rigidbodyOther.transform.parent = transform;
        rigidbodyOther.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (!actuatorNodes.Exists(e => !e.isOn))
        {
            isOpen = true;

            rigidbodyOther.transform.parent = (otherParent == null ? null : otherParent);
            rigidbodyOther.isKinematic = false;
        }
    }
}
