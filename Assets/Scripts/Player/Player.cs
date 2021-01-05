using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;
using CybercowGames;

public class Player : MonoBehaviour
{

    public StateMachine movementSM;
    public StateMachine attackSM;

    public StandingState standing;
    public JumpingState jumping;
    public WallJumpState walljump;

    [SerializeField]
    private List<string> triggers;

    [Header("Combo")]
    [SerializeField]
    private float moveFallOff;
    [SerializeField]
    private float hangTime;

    [Header("Ground Check")]
    [SerializeField]
    private float groundHeight;

    private bool comboLock;

    private Animator anim;
    public Rigidbody rb;
    [SerializeField]
    private GameObject head;

    public Movement movement;

    IEnumerator RemoveFromCombo()
    {
        comboLock = true;
        yield return new WaitForSeconds(moveFallOff);
        if (PlayerState.Instance.Movelist.Count > 0)
        {
            Action removed_action = PlayerState.Instance.Movelist.Remove();
            Debug.Log("Removed move " + removed_action);
        }
        comboLock = false;
    }

    private IEnumerator Attacking()
    {
        rb.velocity = Vector3.zero;
        Camera.Instance.Zoom = true;
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);
        Camera.Instance.Zoom = false;
    }

    private bool IsAttacking()
    {
        bool isAttacking = anim.GetCurrentAnimatorStateInfo(0).IsTag("Attacks");
        return isAttacking;
    }

    public bool IsGrounded()
    {
        RaycastHit hit;
        RaycastHit hit1;
        RaycastHit hit2;
        float offset = 0.75f;


        if (
            Physics.Raycast(new Vector3(transform.position.x - offset, transform.position.y, transform.position.z), Vector3.down, out hit, groundHeight + offset) ||
            Physics.Raycast(transform.position, Vector3.down, out hit1, groundHeight) ||
            Physics.Raycast(new Vector3(transform.position.x + offset, transform.position.y, transform.position.z), Vector3.down, out hit2, groundHeight + offset)
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private bool IsNearLedge()
    {
        RaycastHit hit;
        RaycastHit hit1;
        RaycastHit hit2;
        float offset = 0.25f;

        Debug.DrawRay(new Vector3(head.transform.position.x, head.transform.position.y - offset, head.transform.position.z), Vector3.right, Color.white);
        Debug.DrawRay(head.transform.position, Vector3.right, Color.white);
        Debug.DrawRay(new Vector3(head.transform.position.x, head.transform.position.y + offset, head.transform.position.z), Vector3.right, Color.white);

        if (
            Physics.Raycast(new Vector3(head.transform.position.x, head.transform.position.y - offset, head.transform.position.z), Vector3.right, out hit, groundHeight + offset) ||
            Physics.Raycast(Vector3.right, head.transform.position, out hit1, groundHeight) ||
            Physics.Raycast(new Vector3(head.transform.position.x, head.transform.position.y + offset, head.transform.position.z), Vector3.right, out hit2, groundHeight + offset)
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Flip()
    {
        gameObject.FlipX();
    }

    private bool IsFalling()
    {
        Vector3 vel = rb.velocity;
        if (vel.y <= 0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void CheckDirection()
    {
        PlayerState.Instance.Direction = transform.localScale.x < 0 ? "left" : "right";
    }

    void Awake()
    {
        movementSM = new StateMachine();
        // attackSM = new StateMachine();

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        movement = GetComponent<Movement>();
        standing = new StandingState(this, movementSM);
        jumping = new JumpingState(this, movementSM);
        walljump = new WallJumpState(this, movementSM);
        movementSM.Initialize(standing);
        
        PlayerState.Instance.Combos = GetComponent<ComboManager>().PopulateCombos("Assets/Scripts/SO/Combos");
        PlayerState.Instance.Colliders = gameObject.AddComponent<Collisions>();
        PlayerState.Instance.Grounded = IsGrounded();
        PlayerState.Instance.NearLedge = IsNearLedge();
        CheckDirection();
    }

    private void IgnoreCollision()
    {
        if (PlayerState.Instance.Locks["collisions"]) return;

        if (rb.velocity.y > 0) Physics.IgnoreLayerCollision(0, 8);

        if (rb.velocity.y <= 0)
        {
            Physics.IgnoreLayerCollision(0, 8, false);
        }
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        PlayerState.Instance.Attacking = IsAttacking();
        PlayerState.Instance.Grounded = IsGrounded();
        PlayerState.Instance.NearLedge = IsNearLedge();

        if (PlayerState.Instance.Movelist.Count > 0 && !comboLock) StartCoroutine(RemoveFromCombo());
        if (PlayerState.Instance.Attacking) StartCoroutine(Attacking());

        CheckDirection();
        IgnoreCollision();
        
        movementSM.CurrentState.HandleInput();
        movementSM.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        PlayerState.Instance.Falling = IsFalling();
        movementSM.CurrentState.PhysicsUpdate();
    }

}
