using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Rigidbody2D itemRigidBody;
    public Rigidbody2D playerRigidBody;
    private string tagObject;
    bool hasPlayer = false;
    bool beingCarried = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        itemRigidBody = other.GetComponent<Rigidbody2D>();
        tagObject = other.gameObject.tag;
        hasPlayer = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        hasPlayer = false;
    }

    void Update()
    {
        if (beingCarried)
        {
            if (Input.GetMouseButtonDown(0))
            {
                itemRigidBody.isKinematic = false;
                itemRigidBody.transform.parent = null;
                beingCarried = false;
                transform.position = playerRigidBody.transform.position;
                itemRigidBody.velocity = Vector2.zero;
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && hasPlayer && tagObject.CompareTo("Node") == 0)
            {
                itemRigidBody.isKinematic = true;
                itemRigidBody.transform.parent = playerRigidBody.transform;
                beingCarried = true;
            }
        }
    }
}
