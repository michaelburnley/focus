using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    private List <GameObject> currentCollisions = new List <GameObject> ();
    

    public List <GameObject> collisions {
        get {
            return currentCollisions;
        }
    }


    void OnCollisionEnter (Collision col) {
        currentCollisions.Add(col.gameObject);
        currentCollisions = currentCollisions.Distinct().ToList();
    }
 
    void OnCollisionExit (Collision col) {
        currentCollisions.Remove(col.gameObject);
    }

    public GameObject getCollider(int layer) {
        GameObject found = currentCollisions.Find(item => item.layer == layer);
        return found; 
    }

    public GameObject getCollider(string tag) {
        GameObject found = currentCollisions.Find(item => item.tag == tag);
        return found; 
    }

    public bool isColliding(int layer) {
        GameObject found = currentCollisions.Find(item => item.layer == layer);
        if (found) return true;
        return false;
    }
    public bool isColliding(string tag) {

        GameObject found = currentCollisions.Find(item => item.tag == tag);
        if (found) return true;
        return false;
    }
}
