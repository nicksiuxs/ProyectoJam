using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Rigidbody2D rigidbodyOther;
    public Rigidbody2D playerRigidBody;
    public string objectTag;
    private bool hasObject = false;
    private bool grabFlag = false;
    private Transform otherParent;

    public Animator animator;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == objectTag && !hasObject && Input.GetMouseButtonDown(0))
        {

            rigidbodyOther = other.GetComponent<Rigidbody2D>();
            otherParent = rigidbodyOther.transform.parent;
            rigidbodyOther.isKinematic = true;
            rigidbodyOther.transform.parent = playerRigidBody.transform;

            hasObject = true;
            grabFlag = true;

            animator.SetBool("IsGrab", true);
        }
    }

    void Update()
    {
        if (hasObject && Input.GetMouseButtonDown(0) && !grabFlag)
        {
            rigidbodyOther.isKinematic = false;

            rigidbodyOther.transform.parent = (otherParent == null ? null : otherParent);
            transform.position = playerRigidBody.transform.position;
            rigidbodyOther.velocity = Vector2.zero;
            animator.SetBool("IsGrab", false);
            hasObject = false;
        }
        else if (!Input.GetMouseButtonDown(0))
        {
            grabFlag = false;
        }
    }
}
