using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformMovement : MonoBehaviour
{
    private bool colliding;
    private GameObject platform;

    private void MovePlatform() {
        if(Input.GetKey(KeyCode.UpArrow)) {
            platform.transform.position += Vector3.up * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.DownArrow)) {
            platform.transform.position += Vector3.down * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.LeftArrow)) {
            platform.transform.position += Vector3.left * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.RightArrow)) {
            platform.transform.position += Vector3.right * Time.deltaTime;
        }
    }

    
    void OnCollisionExit(Collision other) {
        colliding = false;
        platform = null;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.gameObject.tag == "Platform") {
            colliding = true;
            platform = collision.collider.gameObject;
        }
    }

    void Update()
    {
        if(colliding) {
            MovePlatform();
        }
    }
}
