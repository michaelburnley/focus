using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    private Renderer renderer;

    private void OnTriggerEnter(Collider collider) {
        if(collider.name == "Player") {
            renderer.enabled = false;
        } else {
            renderer.enabled = true;
        }
    }

    private void Awake() {
        renderer = GetComponent<Renderer>();
    }
}
