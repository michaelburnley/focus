using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class ComboManager : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rb;
    private State state;

    PlayerCombo activecombo = null;

    private void CheckCombo()
    {

        foreach (PlayerCombo combo in state.Combos)
        {
            if (state.Movelist.Compare(combo.Moves))
            {
                activecombo = combo;
                break;
            }
        }

        if (activecombo)
        {

            if (activecombo.Type == ComboType.MOVEMENT)
            {
                StartCoroutine(MovementAnimationYield(activecombo));
            }
            else
            {
                StartCoroutine(AnimationYield(activecombo));
            }
        }

        activecombo = null;
    }

    public virtual IEnumerator AnimationYield(PlayerCombo combo)
    {
        bool validcombo = true;

        foreach (string item in combo.Excludes)
        {
            if (anim.GetBool(item))
            {
                validcombo = false;
                break;
            }

        }

        foreach (string item in combo.Includes)
        {
            if (!anim.GetBool(item))
            {
                validcombo = false;
                break;
            }
        }

        if (validcombo)
        {
            state.Lock("jump");
            state.Lock("direction");
            state.Lock("input");
            state.Lock("flip");

            rb.velocity = Vector3.zero;
            anim.SetBool("Walk", false);
            anim.SetBool(combo.Name, true);

            float animationTime = anim.GetCurrentAnimatorStateInfo(0).length + 0.25f;
            if (combo.AnimTime > 0f)
            {
                anim.speed = animationTime / combo.AnimTime;
                animationTime = combo.AnimTime;
            }

            if (combo.PlayerForce > 0f) rb.AddForce(combo.PlayerDirection * combo.PlayerForce, ForceMode.Impulse);
            yield return new WaitForSeconds(animationTime);
            anim.SetBool(combo.Name, false);
            anim.speed = 1f;


            state.Unlock("input");
            state.Unlock("direction");
            state.Unlock("jump");
        }

    }

    public virtual IEnumerator MovementAnimationYield(PlayerCombo combo)
    {
        state.Lock("collisions");
        List<GameObject> excluded = new List<GameObject>();

        foreach (string item in combo.Excludes)
        {
            GameObject obj = state.getCollider(System.Convert.ToInt32(item));
            Collider col = obj.GetComponent<Collider>();

            if (col != null)
            {
                col.enabled = false;
            }
            obj = null;

        }

        state.Lock("jump");
        state.Lock("direction");
        state.Lock("input");
        state.Lock("flip");

        anim.SetBool(combo.Name, true);
        if (combo.PlayerForce > 0f) rb.AddForce(combo.PlayerDirection * combo.PlayerForce, ForceMode.Impulse);
        yield return new WaitForSeconds(combo.AnimTime);
        if (combo.PlayerForce > 0f) rb.velocity = Vector3.zero;
        anim.SetBool(combo.Name, false);
        foreach (string item in combo.Excludes)
        {
            GameObject obj = state.getCollider(System.Convert.ToInt32(item));
            Collider col = obj.GetComponent<Collider>();
            if (col != null)
            {
                col.enabled = true;
            }
            state.Collisions.Remove(obj);
        }

        excluded.Clear();

        state.Unlock("input");
        state.Unlock("direction");
        state.Unlock("jump");
        state.Unlock("collisions");
    }

    public List<PlayerCombo> PopulateCombos(string asset_folder)
    {
        string[] assetNames = AssetDatabase.FindAssets("t:ScriptableObject", new string[] { "Assets/Scripts/SO/Combos" });

        List<PlayerCombo> combo_list = new List<PlayerCombo>();

        foreach (string SOName in assetNames)
        {
            var SOpath = AssetDatabase.GUIDToAssetPath(SOName);
            var combo = AssetDatabase.LoadAssetAtPath<PlayerCombo>(SOpath);

            if (combo.Active)
            {
                combo_list.Add(combo);

                if (combo.Omnidirectional)
                {
                    PlayerCombo duplicate = Instantiate(combo);
                    List<Action> moves = new List<Action>();

                    foreach (Action move in duplicate.Moves)
                    {
                        switch (move)
                        {
                            case Action.RIGHT:
                                moves.Add(Action.LEFT);
                                break;
                            case Action.LEFT:
                                moves.Add(Action.RIGHT);
                                break;
                            default:
                                moves.Add(move);
                                break;
                        }
                    }

                    duplicate.PlayerDirection = -1 * duplicate.PlayerDirection;
                    duplicate.Direction = -1 * duplicate.Direction;
                    duplicate.Moves = moves.ToArray();
                    combo_list.Add(duplicate);
                }
            }
        }

        return combo_list;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        state = GetComponent<State>();
    }

    private void Update()
    {
        CheckCombo();
    }
}
