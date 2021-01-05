using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Enemy : MonoBehaviour
{

    private List<PlayerCombo> attacks;
    private Rigidbody rb;
    private Animator anim;

    [SerializeField]
    private float groundHeight;
    [SerializeField]
    private float descendSpeed;
    [SerializeField]
    private float bonusGravity;

    public Animator Anim => anim;
    public EnemyState State => state;
    public float DescendSpeed => descendSpeed;
    public float BonusGravity => bonusGravity;

    private EnemyState state;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); 
        state = GetComponent<EnemyState>();
        state.Colliders = gameObject.AddComponent<Collisions>();
        PopulateBehaviors();
    }

    private void PopulateBehaviors() {
        foreach (EnemyBehaviorType type in state.Behaviors) 
        {    
            if (type == EnemyBehaviorType.AIM) gameObject.AddComponent<Aim>();
            if (type == EnemyBehaviorType.BLOCK) gameObject.AddComponent<Block>();
            if (type == EnemyBehaviorType.FLYING) gameObject.AddComponent<Flying>();
            if (type == EnemyBehaviorType.JUMP) gameObject.AddComponent<Jump>();
            if (type == EnemyBehaviorType.MELEE) gameObject.AddComponent<Melee>();
            if (type == EnemyBehaviorType.MOVE) gameObject.AddComponent<Move>();
            if (type == EnemyBehaviorType.SHOOT) gameObject.AddComponent<Shoot>();
        }
    }

    public bool IsGrounded() {
        RaycastHit hit;
        RaycastHit hit1;
        RaycastHit hit2;
        float offset = 0.75f;

        if(
            Physics.Raycast(new Vector3(transform.position.x - offset,transform.position.y, transform.position.z), Vector3.down, out hit, groundHeight + offset) ||
            Physics.Raycast(transform.position, Vector3.down, out hit1, groundHeight) ||
            Physics.Raycast(new Vector3(transform.position.x + offset,transform.position.y, transform.position.z), Vector3.down, out hit2, groundHeight + offset)
        ) {
            return true;
        } else {
            return false;
        }
   }

    IEnumerator OnHit () {
        rb.velocity = Vector3.zero;
        yield return new WaitForSeconds(state.HangTime);
    }

    private void Damage(Collider other) {
        int damage = 0;
        bool isCombo = false;

        switch (other.tag) {
            case "kick":
                Debug.Log("hit with kick");
                damage = PlayerState.Instance.KickDamage;
                break;
            case "punch":
                Debug.Log("hit with punch");
                damage = PlayerState.Instance.PunchDamage;
                break;
            case "combo":
                Debug.Log("hit with combo");
                damage = PlayerState.Instance.ActiveCombo.Damage;
                isCombo = true;
                break;
            default:
                break;
        }

        if(isCombo) {
            rb.AddForce(PlayerState.Instance.ActiveCombo.Direction * PlayerState.Instance.ActiveCombo.Force * state.Multiplier); 
        }
        
        state.Health -= damage;
    }

    private void OnTriggerEnter(Collider other) {
        
        if (
            other.tag == "Player"   || 
            other.tag == "combo"    || 
            other.tag == "kick"     ||
            other.tag == "punch" 
            ) {
            
            Damage(other);
        }
    }

    void Update()
    {
        state.Grounded = IsGrounded();
    }
}
