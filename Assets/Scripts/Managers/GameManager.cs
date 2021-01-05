using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;    
    public static GameManager Instance { get { return _instance; } }

    private void Awake() {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

        Player player = FindObjectOfType<Player>();
        Camera.Instance.Subject = player.gameObject;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
