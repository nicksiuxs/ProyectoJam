using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Rigidbody2D rigidbodyOther;
    public Rigidbody2D playerRigidBody;
    public string objectTag;
    private bool hasObject = false;

    public Animator animator;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == objectTag && !hasObject && Input.GetMouseButtonDown(0))
        {
            animator.SetBool("IsGrab",true);
            rigidbodyOther = other.GetComponent<Rigidbody2D>();
            rigidbodyOther.isKinematic = true;
            rigidbodyOther.transform.parent = playerRigidBody.transform;

            StartCoroutine(updateState(true));
        }
    }

    void Update()
    {
        if (hasObject && Input.GetMouseButtonDown(0))
        {
            rigidbodyOther.isKinematic = false;
            rigidbodyOther.transform.parent = null;
            transform.position = playerRigidBody.transform.position;
            rigidbodyOther.velocity = Vector2.zero;
             animator.SetBool("IsGrab",false);
            StartCoroutine(updateState(false));
        }
    }

    IEnumerator updateState(bool newState)
    {
        yield return new WaitForSeconds(.1f);
        hasObject = newState;
    }
}
