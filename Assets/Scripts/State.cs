using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    [SerializeField]
    private int health;

    private List<PlayerCombo> playerCombos = new List<PlayerCombo>();
    private PlayerCombo activeCombo;
    private List<Equipment> equipment = new List<Equipment>();
    private Collisions colliders;
    private Combo movelist = new Combo(10);


    private bool grounded;
    private bool falling; 
    private bool moving;
    private bool jumping;
    private bool attacking;

    private string direction;

    private Dictionary<string, bool> locks = new Dictionary<string, bool>() {
        { "jump", false },
        { "walljump", false },
        { "direction", false },
        { "input", false },
        { "collisions", false },
        { "flip", false }
    };

    public void Lock(string name) {
        locks[name] = true;
    }
    public void Unlock(string name) {
        locks[name] = false;
    }

    public Dictionary<string, bool> Locks {
        get {
            return locks;
        }
    }

    public List<GameObject> Collisions {
        get {
            return colliders.collisions;
        }
    }

    public Collisions Colliders {
        set {
            colliders = value;
        }
    }

    public bool isColliding(int layer) {
        return colliders.isColliding(layer);
    }
    public bool isColliding(string tag) {
        return colliders.isColliding(tag);
    }

    public GameObject getCollider(int layer) {
        return colliders.getCollider(layer);
    }
    public GameObject getCollider(string tag) {
        return colliders.getCollider(tag);
    }

    public Combo Movelist {
        get {
            return movelist;
        }
    }

    public bool Attacking {
        get {
            return attacking;
        }

        set {
            attacking = value;
        }
    }

    public string Direction {
        get {
            return direction;
        }

        set {
            direction = value;
        }
    }

    public bool Grounded {
        get {
            return grounded;
        }

        set {
            grounded = value;
        }
    }

    public bool Moving {
        get {
            return moving;
        }

        set {
            moving = value;
        }
    }

        public int Health {
        get {
            return health;
        }

        set {
            health = value;
        }
    }

    public bool Falling {
        get {
            return falling;
        }

        set {
            falling = value;
        }
    }

    public bool Jumping {
        get {
            return jumping;
        }

        set {
            jumping = value;
        }
    }

    public PlayerCombo ActiveCombo {
        get {
            return activeCombo;
        }

        set {
            activeCombo = value;
        }
    }

    public List<Equipment> Equipment() {
        return equipment;
    }


    public List<Equipment> Equipment(Equipment equip) {
        if (equipment.Contains(equip) && !equip.AllowDuplicate) {
            return equipment;
        }

        equipment.Add(equip);
        return equipment;
    }

    public List<PlayerCombo> Combos {
        get {
            return playerCombos;
        }

        set {
            playerCombos = value;
        }
    }
}
