using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{

    [Header("Controls")]
    [SerializeField]
    public string up;
    [SerializeField]
    public string left;
    [SerializeField]
    public string right;
    [SerializeField]
    public string down;


    [SerializeField]
    private string focus;
    [SerializeField]
    private string attack1;
    [SerializeField]
    private string attack2;
    [SerializeField]
    private string attack3;

    private Dictionary<string, Action> mappings = new Dictionary<string, Action>();
    private Movement movement;
    private Animator anim;

    private void GenerateMappings()
    {
        mappings.Add(focus, Action.FOCUS);
        mappings.Add(left, Action.LEFT);
        mappings.Add(right, Action.RIGHT);
        mappings.Add(up, Action.UP);
        mappings.Add(down, Action.DOWN);
        mappings.Add(attack1, Action.ATTACK1);
        mappings.Add(attack2, Action.ATTACK2);
        mappings.Add(attack3, Action.ATTACK3);
    }

    private void Awake()
    {
        GenerateMappings();
        movement = GetComponent<Movement>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(up))
        {
            PlayerState.Instance.Movelist.Add(mappings[up]);
            PlayerState.Instance.Jumping = true;
            PlayerState.Instance.Held = "jump";

            anim.SetBool("Punch", false);

            // if (PlayerState.Instance.Grounded)
            // {
            //     movement.Jump();
            // }
            // else
            // {
            //     movement.WallJump();
            // }

        }
        else
        {
            anim.SetBool("Jump", false);
        }

        if (Input.GetKeyUp(up))
        {
            PlayerState.Instance.Held = null;
        }

        if (!Input.GetKey(right) && !Input.GetKey(left))
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKeyDown(right))
        {
            PlayerState.Instance.Movelist.Add(mappings[right]);
        }

        if (Input.GetKeyDown(left))
        {
            PlayerState.Instance.Movelist.Add(mappings[left]);
        }

        if (Input.GetKeyDown(down))
        {
            PlayerState.Instance.Movelist.Add(mappings[down]);
        }

        if (Input.GetKeyDown(attack1))
        {
            anim.SetBool("Punch", true);
            PlayerState.Instance.Movelist.Add(mappings[attack1]);
            // Camera.Instance.Shake(0.5f);
        }
        else
        {
            anim.SetBool("Punch", false);
        }

        if (Input.GetKeyDown(attack2))
        {
            anim.SetBool("Kick", true);
            PlayerState.Instance.Movelist.Add(mappings[attack2]);
        }
        else
        {
            anim.SetBool("Kick", false);
        }

        if (Input.anyKey || !PlayerState.Instance.Grounded || PlayerState.Instance.ActiveCombo)
        {
            PlayerState.Instance.Moving = true;
        }
        else
        {
            PlayerState.Instance.Moving = false;
        }

    }
}