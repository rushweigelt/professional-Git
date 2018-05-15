using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(map_v4))]
public class map_v4_inspector : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("RESPAWN"))
        {
            map_v4 Map_v4 = (map_v4)target;
            Map_v4.destroyTiles();
            Map_v4.buildMapTiles();
            
        }
        
    }

}
