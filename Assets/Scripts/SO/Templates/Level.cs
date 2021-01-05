using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "Level", order = 1)]
public class Level : ScriptableObject
{
    [SerializeField]
    private bool active;
    [SerializeField]
    private string sceneName;

    private string Name => sceneName;
    private bool Active => active;

}
