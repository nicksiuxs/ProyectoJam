using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public Animator animator;
    public string objectTag;
    public Transform grabPosition;
    public Rigidbody2D playerRigidBody;

    private Rigidbody2D rigidbodyOther;
    private bool hasObject = false;
    private bool grabFlag = false;
    private Transform otherParent;



    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == objectTag && !hasObject && Input.GetButtonDown("Grab"))
        {

            rigidbodyOther = other.GetComponent<Rigidbody2D>();
            otherParent = rigidbodyOther.transform.parent;
            rigidbodyOther.isKinematic = true;
            rigidbodyOther.transform.parent = playerRigidBody.transform;
            rigidbodyOther.transform.position = grabPosition.position;

            hasObject = true;
            grabFlag = true;

            animator.SetBool("IsGrab", true);
        }
    }

    void Update()
    {
        if (hasObject && Input.GetButtonDown("Grab") && !grabFlag)
        {
            rigidbodyOther.isKinematic = false;

            rigidbodyOther.transform.parent = (otherParent == null ? null : otherParent);
            rigidbodyOther.velocity = Vector2.zero;
            animator.SetBool("IsGrab", false);
            hasObject = false;
        }
        else if (!Input.GetButtonDown("Grab"))
        {
            grabFlag = false;
        }
    }
}
