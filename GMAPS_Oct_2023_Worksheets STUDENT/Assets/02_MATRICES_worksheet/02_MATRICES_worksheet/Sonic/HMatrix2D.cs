using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

//// Uncomment this whole file

public class HMatrix2D
{
    public float[,] entries { get; set; } = new float[3, 3];

    public HMatrix2D()
    {
        entries = new float[3, 3];
    }

    public HMatrix2D(float[,] multiArray)
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                entries[y, x] = multiArray[y, x];
            }
        }
        //entries = multiArray;
    }

    public HMatrix2D(float m00, float m01, float m02,
             float m10, float m11, float m12,
             float m20, float m21, float m22)
    {
        entries[0, 0] = m00;
        entries[0, 1] = m01;
        entries[0, 2] = m02;
        entries[1, 0] = m10;
        entries[1, 1] = m11;
        entries[1, 2] = m12;
        entries[2, 0] = m20;
        entries[2, 1] = m21;
        entries[2, 2] = m22;
    }

    public static HMatrix2D operator +(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D sum = new HMatrix2D();
        for (int row = 0; row < left.entries.GetLength(0); row++)
        {
            for (int col = 0; col < right.entries.GetLength(1); col++)
            {
                sum.entries[row, col] = left.entries[row, col] + right.entries[row, col];
            }
        }
        return sum;
    }

    public static HMatrix2D operator -(HMatrix2D left, HMatrix2D right)
    {
        HMatrix2D diff = new HMatrix2D();
        for (int row = 0; row < left.entries.GetLength(0); row++)
        {
            for (int col = 0; col < right.entries.GetLength(1); col++)
            {
                diff.entries[row, col ] = left.entries[row, col] - right.entries[row, col];
            }
        }
        return diff;
    }

    public static HMatrix2D operator *(HMatrix2D left, float scalar)
    {
        //return new HMatrix2D(left.entries[] * scalar);
        HMatrix2D product = new HMatrix2D();
        for (int row = 0; row < left.entries.GetLength(0); row++)
        {
            for (int col = 0; col < left.entries.GetLength(1); col++)
            {
                product.entries[row, col] = left.entries[row, col] *= scalar;
            }
        }
        return product;
    }

    // Note that the second argument is a HVector2D object

    public static HVector2D operator *(HMatrix2D left, HVector2D right)
    {
        return new HVector2D
        (
            (left.entries[0,0] * right.x + left.entries[0,1] * right.y),
            (left.entries[1,0] * right.x + left.entries[1,1] * right.y)
        );
    }

    // Note that the second argument is a HMatrix2D object
    //
    public static HMatrix2D operator *(HMatrix2D left, HMatrix2D right)
    {
        return new HMatrix2D
        (
            /* 
                00 01 02    00 xx xx
                xx xx xx    10 xx xx
                xx xx xx    20 xx xx
                */
            left.entries[0, 0] * right.entries[0, 0] + left.entries[0, 1] * right.entries[1, 0] + left.entries[0, 2] * right.entries[2, 0],

            /* 
                00 01 02    xx 01 xx
                xx xx xx    xx 11 xx
                xx xx xx    xx 21 xx
                */
            left.entries[0, 0] * right.entries[0, 1] + left.entries[0, 1] * right.entries[1, 1] + left.entries[0, 2] * right.entries[2, 1],

            // and so on for another 7 entries
            left.entries[0, 0] * right.entries[0, 2] + left.entries[0, 1] * right.entries[1, 2] + left.entries[0, 2] * right.entries[2, 2],

            left.entries[1, 0] * right.entries[0, 0] + left.entries[1, 1] * right.entries[1, 0] + left.entries[1, 2] * right.entries[2, 0],

            left.entries[1, 0] * right.entries[0, 1] + left.entries[1, 1] * right.entries[1, 1] + left.entries[1, 2] * right.entries[2, 1],

            left.entries[1, 0] * right.entries[0, 2] + left.entries[1, 1] * right.entries[1, 2] + left.entries[1, 2] * right.entries[2, 2],

            left.entries[2, 0] * right.entries[0, 0] + left.entries[2, 1] * right.entries[1, 0] + left.entries[2, 2] * right.entries[2, 0],

            left.entries[2, 0] * right.entries[0, 1] + left.entries[2, 1] * right.entries[1, 1] + left.entries[2, 2] * right.entries[2, 1],

            left.entries[2, 0] * right.entries[0, 2] + left.entries[2, 1] * right.entries[1, 2] + left.entries[2, 2] * right.entries[2, 2]

       );
    }

    public static bool operator ==(HMatrix2D left, HMatrix2D right)
    {
        for (int row = 0; row < left.entries.GetLength(0); row++)
        {
            for (int col = 0; col < right.entries.GetLength(1); col++)
            {
                if (left.entries[row, col] != right.entries[row, col])
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static bool operator !=(HMatrix2D left, HMatrix2D right)
    {
        for (int row = 0; row < left.entries.GetLength(0); row++)
        {
            for (int col = 0; col < right.entries.GetLength(1); col++)
            {
                if (left.entries[row, col] == right.entries[row, col])
                {
                    return false;
                }
            }
        }
        return true;
    }

    //public override bool Equals(object obj)
    //{
    //    // your code here
    //}

    //public override int GetHashCode()
    //{
    //    // your code here
    //}

    //public HMatrix2D transpose()
    //{
    //    return // your code here
    //}

    //public float getDeterminant()
    //{
    //    return // your code here
    //}

    public void setIdentity()
    {
        for (int y = 0; y < 3; y++)
        {
            for (int x = 0; x < 3; x++)
            {
                entries[y, x] = x == y ? entries[y, x] = 1 : entries[y, x] = 0;
                //if (x == y)
                //{
                //    entries[y, x] = 1;
                //}
                //else
                //{
                //    entries[y, x] = 0;
                //}
            }
        }
    }

    //public void setTranslationMat(float transX, float transY)
    //{
    //    // your code here
    //}

    public void setRotationMat(float rotDeg)
    {
        setIdentity();
        float rad = rotDeg * Mathf.Deg2Rad;
        entries[0, 0] = (Mathf.Cos(rad) * entries[0, 0]);
        entries[0, 1] = (-Mathf.Sin(rad) * entries[0, 1]);
        entries[1, 0] = (Mathf.Sin(rad) * entries[1, 0]);
        entries[1, 1] = (Mathf.Cos(rad) * entries[1, 1]);
    }

    //public void setScalingMat(float scaleX, float scaleY)
    //{
    //    // your code here
    //}

    public void Print()
    {
        string result = "";
        for (int r = 0; r < 3; r++)
        {
            for (int c = 0; c < 3; c++)
            {
                result += entries[r, c] + "  ";
            }
            result += "\n";
        }
        Debug.Log(result);
    }
}
