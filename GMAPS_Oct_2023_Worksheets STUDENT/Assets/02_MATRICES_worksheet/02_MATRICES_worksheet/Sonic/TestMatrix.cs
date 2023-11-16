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
        mat1 = new HMatrix2D(1, 4, 2,
            3, 3, 6, 
            8, 5, 0);
        mat2 = new HMatrix2D(2, 5, 1,
            6, 7, 1,
            1, 8, 1);
        resultMat = mat1 * mat2;
        resultMat.Print();
    }
}
