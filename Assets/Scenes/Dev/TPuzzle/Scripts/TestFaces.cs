using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFaces : MonoBehaviour
{
    public PuzzleFace face;

    private void Update()
    {
        if (face.CheckAllVertexColliding())
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
    }
}
