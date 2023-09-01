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

    public bool checkFigureIsComplete()
    {
        foreach(PuzzleFace face in faces) {
            if (!face.inCorrectPosition)
            {
                if (!face.CheckAllVertexColliding())
                {
                    return false;
                }
            }
        }
        return true;
    }

    private void Update()
    {
        if(checkFigureIsComplete())
        {
            print("Complete");
        }
    }

    private void Awake()
    {
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