using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo
{
    private int length;
    private List<Action> actions = new List<Action>();

    public int Count => actions.Count;

    public Combo(int set_length) {
        length = set_length;
        actions.Capacity = set_length;
    }

    public List<Action> Add(Action action) {
        if (actions.Count >= length) {
            actions.RemoveAt(0);
        }
        actions.Add(action);
        return actions;
    }

    public Action Remove() {
        Action removed_element = actions[0];
        actions.RemoveAt(0);
        return removed_element;

    }

    public bool Compare(Action[] move_list) {
        List<Action> combo_actions = new List<Action>();

        if (actions.Count <= 1) {
            return false;
        }

        foreach(Action move in move_list) {
            if (actions.Contains(move)) {
                combo_actions.Add(move);
            }
        }

        bool containsSameSequence = actions.ContainsSubsequence(combo_actions);

        if (containsSameSequence) {
             actions = actions.Except(combo_actions).ToList();
        }

        return containsSameSequence;

    }

}
