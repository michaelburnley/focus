using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rb;
    EnemyState state;
    Enemy me;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        me = GetComponent<Enemy>();
        state = GetComponent<EnemyState>();
    }

    private void StartJump() {
        if (!state.Grounded) return;

        rb.velocity = new Vector3(0, state.JumpDistance, 0);
        // me.Anim.SetBool("Jump", true);
    }

    private void Update() {
        StartJump();
    }

    private void ManageJumpSpeed() {
        if (state.Grounded) return;

        if (rb.velocity.y > 0f) {

            Vector3 vel = rb.velocity;
            vel.y -= me.BonusGravity *Time.deltaTime;
            rb.velocity=vel;
        }
    }

    private void ManageFallSpeed() {
        if (state.Grounded) return;
        
        if (rb.velocity.y < 0f) {
            rb.velocity += Vector3.up * Physics.gravity.y * me.DescendSpeed * Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        ManageJumpSpeed();
        ManageFallSpeed();
    }
}
