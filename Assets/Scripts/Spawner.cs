using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private string path;

    private void SelectPrefab() {
        string[] assetNames = AssetDatabase.FindAssets("t:Prefab", new string[] { path });
        var chosen_prefab = assetNames[Random.Range(0, assetNames.Length)];
        var prefab_path = AssetDatabase.GUIDToAssetPath(chosen_prefab);

        prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefab_path);
    }
    
    private void Awake() {
        if (!prefab) SelectPrefab();

        Instantiate(prefab);
        Destroy(gameObject);
    }
}