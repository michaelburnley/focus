using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    Rigidbody rb;
    EnemyState state;
    Enemy me;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        me = GetComponent<Enemy>();
        state = GetComponent<EnemyState>();
    }

    private void StartMove() {
        // if (!state.Grounded) return;

        // rb.velocity = new Vector3(0, state.JumpDistance, 0);
        // me.Anim.SetBool("Jump", true);
    }

    private void Update() {
        StartMove();
    }

    private void FixedUpdate() {

    }
}
