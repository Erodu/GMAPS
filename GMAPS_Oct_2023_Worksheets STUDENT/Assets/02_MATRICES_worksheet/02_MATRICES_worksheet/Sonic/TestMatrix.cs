// Uncomment this whole file.

using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();
    private HMatrix2D mat1;
    private HMatrix2D mat2;
    private HMatrix2D resultMat;
    private HVector2D vec1;

    void Start()
    {
        Question2();
        //mat.setIdentity();
        //mat.Print();
    }

    void Question2()
    {
        mat1 = new HMatrix2D(3, 1, 1,
            4, 7, 9, 
            1, 5, 5);
        mat2 = new HMatrix2D(2, 5, 1,
            6, 7, 1,
            1, 8, 1);
        resultMat = mat1 * mat2;
        resultMat.Print();
    }
}
