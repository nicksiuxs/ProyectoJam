using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedController : MonoBehaviour
{
    public int groundMask;
    public PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == groundMask)
        {
            playerController.setIsGrounded(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == groundMask)
        {
            playerController.setIsGrounded(false);
        }
    }
}
