using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rig;

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rig.linearVelocity = new Vector2(moveInput * moveSpeed, rig.linearVelocity.y);
    }
}
