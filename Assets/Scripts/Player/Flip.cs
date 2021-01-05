using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
   private string prev;
   private string next;

   public void Horizontal(GameObject obj) {
       Transform transform = obj.transform;
       transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
   }
   public void Vertical(GameObject obj) {
       Transform transform = obj.transform;
       transform.localScale = new Vector3(1, transform.localScale.x * -1, 1);
   }

}
