using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyState : State
{
    [SerializeField]
    private float multiplier;
    [SerializeField]
    private EnemyType type;
    [SerializeField]
    private EnemyBehaviorType[] behaviors;

    [SerializeField]
    private float hangTime;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float vision;


    [SerializeField]
    private float blockTime;
    [SerializeField]
    private int jumpDistance;
    [SerializeField]
    private bool jumpDown;


    [SerializeField]
    private int attackDamage;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private Vector3 attackPushDirection;
    [SerializeField]
    private float attackPushForce;
    


    [SerializeField]
    private bool randomMovementDistance;
    [SerializeField]
    private float movementX;
    [SerializeField]
    private float movementY;


    [SerializeField]
    private float fireRange;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private GameObject bullet;

    private float throwSpeed;    

    public EnemyBehaviorType[] Behaviors => behaviors;


    public float Multiplier {
        get {
            return multiplier;
        }

        set {
            multiplier = value;
        }
    }

    public EnemyType Type {
        get {
            return type;
        }

        set {
            type = value;
        }
    }

    public float HangTime {
        get {
            return hangTime;
        }

        set {
            hangTime = value;
        }
    }

    public float Speed {
        get {
            return speed;
        }

        set {
            speed = value;
        }
    }

    public float Vision {
        get {
            return vision;
        }

        set {
            vision = value;
        }
    }

    public float BlockTime {
        get {
            return blockTime;
        }

        set {
            blockTime = value;
        }
    }

    public int JumpDistance {
        get {
            return jumpDistance;
        }

        set {
            jumpDistance = value;
        }
    }

    public bool JumpDown {
        get {
            return jumpDown;
        }

        set {
            jumpDown = value;
        }
    }

    public int AttackDamage {
        get {
            return attackDamage;
        }

        set {
            attackDamage = value;
        }
    }

    public float AttackRange {
        get {
            return attackRange;
        }

        set {
            attackRange = value;
        }
    }

    public Vector3 AttackDirection {
        get {
            return attackPushDirection;
        }

        set {
            attackPushDirection = value;
        }
    }

    public float AttackForce {
        get {
            return attackPushForce;
        }

        set {
            attackPushForce = value;
        }
    }

    public bool MovementDistance {
        get {
            return randomMovementDistance;
        }

        set {
            randomMovementDistance = value;
        }
    }

    public float HorizontalMove {
        get {
            return movementX;
        }

        set {
            movementX = value;
        }
    }

    public float VerticalMove {
        get {
            return movementY;
        }

        set {
            movementY = value;
        }
    }

    public float FireRange {
        get {
            return fireRange;
        }

        set {
            fireRange = value;
        }
    }

    public float BulletSpeed {
        get {
            return bulletSpeed;
        }

        set {
            bulletSpeed = value;
        }
    }

    public GameObject Bullet {
        get {
            return bullet;
        }

        set {
            bullet = value;
        }
    }

    public float ThrowSpeed {
        get {
            return throwSpeed;
        }

        set {
            throwSpeed = value;
        }
    }
}
