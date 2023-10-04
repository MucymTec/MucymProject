using System;
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
    public PuzzleFace[] faces;
    public UI_Manager4E manager;

    //Todo: Implementar llamar desde un boton de evento.
    public void CheckFigureIsComplete()
    {
        foreach(PuzzleFace face in faces) {
                if (!face.CheckAllVertexColliding())
                {
                    print("Not complete");
                    return;
                }
        }
        manager.ShowVictoryScreen();
        return;
    }

    private void Awake()
    {
        faces = GetComponentsInChildren<PuzzleFace>();
        foreach (PuzzleFace face in faces) {
            face.SetVertexTargets();
        }
    }
}

//No puedo implementar el boton.
//#if UNITY_EDITOR
//[CustomEditor(typeof(PuzzleFigure))]
//public class PuzzleFigureEditor : Editor
//{

//    SerializedProperty faces;
//    private void OnEnable()
//    {
//        faces = serializedObject.FindProperty("faces");
//    }
//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();

//        PuzzleFigure figure = (PuzzleFigure)target;

//        if (GUILayout.Button("Setear caras de figura."))

            
//            for (int i = 0;i < figure.GetComponentsInChildren<PuzzleFace>().Length;i++)
//            {
//                PuzzleFace fig =  figure.GetComponentsInChildren<PuzzleFace>()[i];
//                faces.GetArrayElementAtIndex(i).objectReferenceValue = fig;
//                serializedObject.ApplyModifiedProperties();
//            }

//        DrawDefaultInspector();
//    }

//}
//#endif