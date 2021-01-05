using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    private static GameState _instance;
    public static GameState Instance { get { return _instance; } }

    private void Awake() {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    private int comboCount;
    private int deaths;
    private int score;
    private float multiplier;

    public int ComboCount {
        get {
            return comboCount;
        }

        set {
            comboCount = value;
        }
    }
    public float Multiplier {
        get {
            return multiplier;
        }

        set {
            if (value > 0f) multiplier = value;
        }
    }
    public int Score {
        get {
            return score;
        }

        set {
            score += (int)(value * multiplier);
        }
    }
}
