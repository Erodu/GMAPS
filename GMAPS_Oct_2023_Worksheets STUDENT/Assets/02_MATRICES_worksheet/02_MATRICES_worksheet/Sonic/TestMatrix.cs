// Uncomment this whole file.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMatrix : MonoBehaviour
{
    private HMatrix2D mat = new HMatrix2D();
    HMatrix2D mat1;
    HMatrix2D mat2;
    HMatrix2D resultMat;
    HVector2D vec1;

    void Start()
    {
        mat.setIdentity();
        mat.Print();

        Question2();
    }

    void Question2()
    {
        mat1 = new HMatrix2D(1, 2, 1, 
            0, 1, 0, 
            2, 3, 4);
        mat2 = new HMatrix2D(2, 5, 1, 
            6, 7, 1, 
            1, 8, 1);
        resultMat = mat1 * mat2;
        resultMat.Print();
    }
}
