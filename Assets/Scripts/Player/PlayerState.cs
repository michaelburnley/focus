using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerState : State {
    private static PlayerState _instance;
    
    public static PlayerState Instance { get { return _instance; } }

    private void Awake() {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }


    [SerializeField]
    private int punchDamage;
    [SerializeField]
    private int kickDamage;
 
    private bool nearLedge;

    private string held;

    private string current_input;


    public string Held {
        get {
            return held;
        }

        set {
            held = value;
        }
    }

    public int PunchDamage {
        get {
            return punchDamage;
        }

        set {
            punchDamage = value;
        }
    }

    public int KickDamage {
        get {
            return kickDamage;
        }

        set {
            kickDamage = value;
        }
    }

    public bool NearLedge {
        get {
            return nearLedge;
        }

        set {
            nearLedge = value;
        }
    }
}
