using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static bool ContainsSubsequence<T>(this List<T> parent, List<T> target)
    {
        var pattern = target.ToArray();
        var source = new LinkedList<T>();
        foreach (var element in parent) 
        {
            source.AddLast(element);
            if(source.Count == pattern.Length)
            {
                if(source.SequenceEqual(pattern))
                    return true;
                source.RemoveFirst();
            }
        }
        return false;
    }

    public static void FlipX(this GameObject obj) {
       Transform transform = obj.transform;
       transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
   }
   public static void FlipY(this GameObject obj) {
       Transform transform = obj.transform;
       transform.localScale = new Vector3(1, transform.localScale.y * -1, 1);
   }
}
