using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BasicTower))]
public class BasicTowerEditor : Editor
{
    public BasicTower _target
    {
        get => (BasicTower)target;
    }
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        EditorGUILayout.BeginHorizontal();
        
            if (GUILayout.Button("Single hit"))
                _target.AtackOneTarget();

            if (GUILayout.Button("All hit"))
                _target.AtackAllTarget();
        
        EditorGUILayout.EndHorizontal();
    }
}