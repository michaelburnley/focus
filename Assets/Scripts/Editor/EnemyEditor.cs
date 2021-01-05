using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    // private Enemy m_target;
    // SerializedProperty m_multiplier;
    // SerializedProperty m_type;
    // SerializedProperty m_hangTime;
    // SerializedProperty m_speed;
    // SerializedProperty m_vision;
    // SerializedProperty m_blockTime;

    // SerializedProperty m_enabledBehaviors;
    // SerializedProperty m_enableAim;
    // SerializedProperty m_enableAvoid;
    // SerializedProperty m_enableBlock;
    // SerializedProperty m_enableFlying;

    // SerializedProperty m_enableJump;
    // SerializedProperty m_jumpDown;
    // SerializedProperty m_jumpDistance;

    // SerializedProperty m_enableMelee;
    // SerializedProperty m_attackDamage;
    // SerializedProperty m_attackRange;
    // SerializedProperty m_attackPushDirection;
    // SerializedProperty m_attackPushForce;

    // SerializedProperty m_enableMove;
    // SerializedProperty m_randomMovementDistance;
    // SerializedProperty m_movementX;
    // SerializedProperty m_movementY;

    // SerializedProperty m_enableShoot;
    // SerializedProperty m_fireRange;
    // SerializedProperty m_bulletSpeed;
    // SerializedProperty m_bulletPrefab;
    
    // SerializedProperty m_enableThrow;

    // SerializedProperty m_health;
    void OnEnable()
    {
        // Debug.Log("OnEnable is called");
        // m_target = (Enemy)target;
        // m_health = serializedObject.FindProperty("health");
        // m_multiplier = serializedObject.FindProperty("multiplier");
        // m_type = serializedObject.FindProperty("type");
        // m_hangTime = serializedObject.FindProperty("hangTime");
        // m_speed = serializedObject.FindProperty("speed");
        // m_vision = serializedObject.FindProperty("vision");

        // m_enabledBehaviors = serializedObject.FindProperty("enabledBehaviors");
        // m_blockTime = serializedObject.FindProperty("blockTime");
        // m_enableAim = serializedObject.FindProperty("enableAim");
        // m_enableAvoid = serializedObject.FindProperty("enableAvoid");
        // m_enableBlock = serializedObject.FindProperty("enableBlock");
        // m_enableFlying = serializedObject.FindProperty("enableFlying");
        // m_enableMelee = serializedObject.FindProperty("enableMelee");
        // m_attackDamage = serializedObject.FindProperty("attackDamage");
        // m_attackRange = serializedObject.FindProperty("attackRange");
        // m_attackPushDirection = serializedObject.FindProperty("attackPushDirection");
        // m_attackPushForce = serializedObject.FindProperty("attackPushForce");

        // m_enableJump = serializedObject.FindProperty("enableJump");
        // m_jumpDown =  serializedObject.FindProperty("jumpDown");
        // m_jumpDistance =  serializedObject.FindProperty("jumpDistance");

        // m_enableMove = serializedObject.FindProperty("enableMove");
        // m_randomMovementDistance = serializedObject.FindProperty("randomMovementDistance");
        // m_movementX = serializedObject.FindProperty("movementX");
        // m_movementY = serializedObject.FindProperty("movementY");

        // m_enableShoot = serializedObject.FindProperty("enableShoot");
        // m_fireRange = serializedObject.FindProperty("fireRange");
        // m_bulletSpeed = serializedObject.FindProperty("bulletSpeed");
        // m_bulletPrefab = serializedObject.FindProperty("bullet");
        
        // m_enableThrow = serializedObject.FindProperty("enableThrow");
    }
    // void OnDisable() {
    //     Debug.Log("OnDisable is called");
    // }
    
    // void OnDestroy() {
    //     Debug.Log("OnDestroy is called");
    // }
    
    // public override void OnInspectorGUI() {
    //     EditorGUILayout.PropertyField(m_health);
    //     EditorGUILayout.PropertyField(m_multiplier);
    //     EditorGUILayout.PropertyField(m_type);
    //     EditorGUILayout.PropertyField(m_hangTime);
    //     EditorGUILayout.PropertyField(m_speed);
    //     EditorGUILayout.PropertyField(m_vision);
        
        
    //     EditorGUILayout.LabelField("Behaviors", EditorStyles.boldLabel);
    //     EditorGUI.indentLevel++;

    //     m_enableBlock.boolValue = EditorGUILayout.ToggleLeft("Block", m_enableBlock.boolValue);
    //     m_enableAim.boolValue = EditorGUILayout.ToggleLeft("Aim", m_enableAim.boolValue);
    //     m_enableAvoid.boolValue = EditorGUILayout.ToggleLeft("Avoid", m_enableAvoid.boolValue);
    //     m_enableFlying.boolValue = EditorGUILayout.ToggleLeft("Flying", m_enableFlying.boolValue);

    //     m_enableMelee.boolValue = EditorGUILayout.ToggleLeft("Melee", m_enableMelee.boolValue);
    //     if (m_enableMelee.boolValue) {

    //         EditorGUI.indentLevel++;
    //         EditorGUI.indentLevel++;
    //         EditorGUILayout.PropertyField(m_attackDamage, new GUIContent("Damage"));
    //         EditorGUILayout.PropertyField(m_attackRange, new GUIContent("Range"));
    //         EditorGUILayout.PropertyField(m_attackPushForce, new GUIContent("Force"));
    //         EditorGUILayout.PropertyField(m_attackPushDirection, new GUIContent("Direction"));
    //         EditorGUI.indentLevel--;
    //         EditorGUI.indentLevel--;
    //     }

    //     m_enableJump.boolValue = EditorGUILayout.ToggleLeft("Jump", m_enableJump.boolValue);
    //     if (m_enableJump.boolValue) {

    //         EditorGUI.indentLevel++;
    //         EditorGUI.indentLevel++;
    //         EditorGUILayout.PropertyField(m_jumpDown, new GUIContent("Jump down?"));
    //         EditorGUILayout.PropertyField(m_jumpDistance);
    //         EditorGUI.indentLevel--;
    //         EditorGUI.indentLevel--;
    //     }
       
    //     m_enableMove.boolValue = EditorGUILayout.ToggleLeft("Move", m_enableMove.boolValue);
    //     if (m_enableMove.boolValue) {

    //         EditorGUI.indentLevel++;
    //         EditorGUI.indentLevel++;
    //         EditorGUILayout.PropertyField(m_randomMovementDistance, new GUIContent("Randomize"));
    //         EditorGUILayout.PropertyField(m_movementX, new GUIContent("Max X"));
    //         EditorGUILayout.PropertyField(m_movementY, new GUIContent("Max Y"));
    //         EditorGUI.indentLevel--;
    //         EditorGUI.indentLevel--;
    //     }
        
    //     m_enableShoot.boolValue = EditorGUILayout.ToggleLeft("Shoot", m_enableShoot.boolValue);
    //     if (m_enableShoot.boolValue) {

    //         EditorGUI.indentLevel++;
    //         EditorGUI.indentLevel++;
    //         EditorGUILayout.PropertyField(m_fireRange);
    //         EditorGUILayout.PropertyField(m_bulletSpeed);
    //         EditorGUILayout.PropertyField(m_bulletPrefab);
    //         EditorGUI.indentLevel--;
    //         EditorGUI.indentLevel--;
    //     }

    //     serializedObject.ApplyModifiedProperties();
    // }
}
