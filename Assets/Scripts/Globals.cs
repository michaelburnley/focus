using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    // static public Combo combolist = new Combo(4);
    static public List<PlayerCombo> combolist = new List<PlayerCombo>();

    static public int ComboCount => combolist.Count;
    
}