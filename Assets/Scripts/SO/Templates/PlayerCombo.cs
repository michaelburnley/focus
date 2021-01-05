using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

[CreateAssetMenu(fileName = "PlayerCombo", menuName = "Combo", order = 1)]
public class PlayerCombo : ScriptableObject
{
    [SerializeField]
    private bool active;
    [SerializeField]
    private string name;

    [SerializeField]
    private ComboType type;
    [SerializeField]
    private bool omnidirectional;
    [SerializeField]
    private Directional mustFace;

    [SerializeField]
    private Action[] moves;
    [SerializeField]
    private float animationTime;
    
    [SerializeField]
    private AnimatorController animationController;

    [Header("Enemy Effect")]
    [SerializeField]
    private float force;
    [SerializeField]
    private int damage;
    [SerializeField]
    private Vector3 direction;

    [Header("Player Effect")]
    [SerializeField]
    private float playerForce;
    [SerializeField]
    private Vector3 playerDirection;

    [Header("Check Against")]
    [SerializeField]
    private string[] includes;
    [SerializeField]
    private string[] excludes;

    
    
    public string Name => name;
    public bool Active => active;
    public bool Omnidirectional => omnidirectional;
    public ComboType Type => type;
    public string[] Excludes => excludes;
    public string[] Includes => includes;
    public int Damage => damage;
    public float AnimTime => animationTime;

    public Action[] Moves {
        get {
            return moves;
        }

        set {
            moves = value;
        }
    }

    public Directional MustFace {
        get {
            return mustFace;
        }

        set {
            mustFace = value;
        }
    }

    public float PlayerForce { 
        get { return playerForce; }
        set { playerForce = value;}
    }
    public Vector3 PlayerDirection { 
        get { return playerDirection; }
        set { playerDirection = value;}
    }
    public Vector3 Direction { 
        get { return direction; }
        set { direction = value;}
    }
    public float Force { 
        get { return force; }
        set { force = value;}
    }
}