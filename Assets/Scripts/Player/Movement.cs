using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{

    [SerializeField]
    private float movementDelay;

    [Header("Speed/Distance")]
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float maxSpeed;

    [SerializeField]
    private float runDistance;

    [SerializeField]
    private float descendSpeed;
    [SerializeField]
    private float maxDescendSpeed;
    [SerializeField]
    private float bonusGravity;

    [Header("Jump")]
    [SerializeField]
    private float jumpDistance;
    [SerializeField]
    private float jumpCounterForce;

    [Header("Wall Jump")]
    [SerializeField]
    private float wallFallOff;
    [SerializeField]
    private float wallJumpForce;

    private float runSpeed;

    private Animator anim;
    private Rigidbody rb;
    public IEnumerator coroutine;
    public State state;
    private bool isPlayerState;
    private bool wasFalling;
    public Inputs inputs;

    public void Horizontal()
    {
        if (state.Locks["input"]) return;

        if (state.Attacking) return;

        if (!Input.GetKey(inputs.right) && !Input.GetKey(inputs.left))
        {
            runSpeed = 0f;
            return;
        }

        if (!state.Grounded) runSpeed = maxSpeed;

        string requested = Input.GetKey(inputs.right) ? "right" : "left";

        if (requested != state.Direction)
        {
            
            if (state.Locks["direction"]) return;
            if (!state.Locks["flip"]) gameObject.FlipX();
        }
        

        anim.SetBool("Walk", true);

        if (runSpeed <= maxSpeed)
        {
            runSpeed += acceleration;
        }
        else
        {
            runSpeed = maxSpeed;
        }

        float x = requested == "right" ? runDistance : runDistance * -1;
        Vector3 direction = new Vector3(x * Time.deltaTime * runSpeed, rb.velocity.y, 0);
        rb.velocity = direction;

    }

    public void StartWallHang() {
        StartCoroutine(coroutine);
    }

    public void StopWallHang() {
        StopCoroutine(coroutine);
    }


    IEnumerator WallHangTime()
    {
        state.Direction = state.Direction == "left" ? "right" : "left";
        // gameObject.FlipX();
        anim.SetBool("WallHang", true);
        state.Lock("direction");
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        state.Lock("input");
        yield return new WaitForSeconds(wallFallOff);
        rb.useGravity = true;
        state.Unlock("input");
        state.Unlock("direction");
        anim.SetBool("WallHang", false);
    }

    public void WallJump()
    {

        float direction = state.Direction == "left" ? wallJumpForce * -1 : wallJumpForce;

        rb.useGravity = true;
        rb.velocity = new Vector3(-direction, wallJumpForce, 0);
        anim.SetBool("WallHang", false);
        anim.SetBool("Jump", true);

        // state.Unlock("flip");
        // gameObject.FlipX();

        state.Unlock("direction");
        state.Unlock("input");

        StopCoroutine(coroutine);
    }

    public void Jump()
    {
        rb.velocity = new Vector3(0, jumpDistance, 0);
        anim.SetBool("Jump", true);
    }
    
    public void Jump(Vector3 direction)
    {
        rb.velocity = direction;
        anim.SetBool("Jump", true);
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        state = GetComponent<State>();
        inputs = GetComponent<Inputs>();
        runSpeed = 0f;

        isPlayerState = state.GetType() == typeof(PlayerState);
    }

    private void Start()
    {
        coroutine = WallHangTime();
    }

    private void Update()
    {
        if (wasFalling && !state.Falling && !state.Jumping) rb.velocity = Vector3.zero;

        coroutine = WallHangTime();

        if (state.isColliding("Wall"))
        {

            // if (!state.Locks["flip"]) gameObject.FlipX();

            // state.Lock("flip");
            state.Lock("direction");
            anim.SetBool("Walk", false);

        }
        else
        {
            state.Unlock("direction");
            state.Unlock("flip");
            state.Unlock("walljump");
        }

        if (!state.Grounded && state.isColliding("Wall") && !state.Locks["walljump"])
        {
            state.Lock("walljump");
            // StartCoroutine(coroutine);
        }

        if (!state.isColliding("Wall")) state.Unlock("walljump");

        if (state.isColliding("Wall") && state.Grounded) state.Unlock("input");

        if (state.Grounded)
        {
            anim.SetBool("inAir", false);
            state.Unlock("walljump");
        }
        else
        {
            anim.SetBool("inAir", true);
        }

        wasFalling = state.Falling;
    }

    private void ManageJumpHeight()
    {
        if (state.Jumping)
        {
            if (PlayerState.Instance.Held != "jump" && rb.velocity.y > 0)
            {
                rb.AddForce(Vector3.down * jumpCounterForce * rb.mass);
            }
        }
    }

    private void ManageJumpSpeed()
    {
        if (state.Grounded) return;

        if (rb.velocity.y > 0f)
        {

            Vector3 vel = rb.velocity;
            vel.y -= bonusGravity * Time.deltaTime;
            rb.velocity = vel;
        }
    }
    private void ManageFallSpeed()
    {
        if (state.Grounded) return;

        if (rb.velocity.y < 0f && rb.velocity.y > -maxDescendSpeed)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * descendSpeed * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (!state.ActiveCombo)
        {

            ManageJumpSpeed();
            ManageFallSpeed();

            if (isPlayerState) ManageJumpHeight();
        }
    }

}
