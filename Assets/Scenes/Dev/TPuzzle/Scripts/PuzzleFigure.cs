using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class PuzzleFigure : MonoBehaviour
{
    //Check all contained PuzzleFaces
    //If one vertex is touching another then asing as target face.

}

#if UNITY_EDITOR
[CustomEditor(typeof(PuzzleFigure))]
public class PuzzleFigureEditor : Editor
{
    public override void OnInspectorGUI()
    {
;
        PuzzleFigure puzzleFigure = (PuzzleFigure)target;
        if (puzzleFigure == null) return;

        if (GUILayout.Button("Setear caras de figura."))
        {
            Debug.Log("Seteando caras");
        }

        DrawDefaultInspector();
    }

}
#endif