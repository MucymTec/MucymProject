using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//It works in editor mode.
[ExecuteInEditMode]
public class PuzzleFace : MonoBehaviour
{
    public float width = 1f;
    public float height = 1f;
    //Hacer mas pequena esta escala si se quiere que el choque entre las partes se mas preciso. Hacer mas grande si se quiere dar mas facilidad de que se encuentren las caras.
    public float vertexScale = .1f;
    public PuzzleVertex[] vertices;
    public bool inCorrectPosition;

    private void Awake()
    {
        vertices = transform.GetComponentsInChildren<PuzzleVertex>();
    }

    public void SetVertexTargets()
    {
        foreach (PuzzleVertex vertex in vertices)
        {
            vertex.DetectTargetVertex(); 
        }
    }

    //Triggered when the size is changed in the editor.
    public void ChageSize()
    {
        foreach (PuzzleVertex vertex in vertices)
        {
            vertex.AdjustSize(vertexScale);
        }
    }

    //Used to check if the face is in the correct position with the targetFace
    public bool CheckAllVertexColliding()
    {
        foreach (PuzzleVertex vertex in vertices)
        {
            
            if (!vertex.IsCollidingWithTarget()) 
            {
                inCorrectPosition = false;
                return false;
            }
        }
        inCorrectPosition = true;
        return true;
    }

    private void OnValidate()
    {
        ChageSize();
    }

}
