using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Equipment", order = 1)]
public class Equipment : ScriptableObject {
    
    [SerializeField]
    private string name;

    [SerializeField]
    private EquipmentType type;

    [SerializeField]
    private Sprite icon;

    [SerializeField]
    private bool allowDuplicates;

    [SerializeField]
    private bool stackable;

    [SerializeField]
    private int qty;

    [SerializeField]
    private int maxStack;

    [SerializeField]
    private GameObject prefab;

    private int Qty => qty;
    public string Name => name;
    private bool Stackable => stackable;
    private int MaxStack => maxStack;
    public bool AllowDuplicate => allowDuplicates;
    public EquipmentType Type => type;
    public GameObject Prefab => prefab;
    public Sprite Icon => icon;
}
