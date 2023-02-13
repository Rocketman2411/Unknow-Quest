using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;

public class SplineGenerator : MonoBehaviour
{
    private List<Vector3> points;
    /*
    public float[] GetCoeff()
    {
        
        return coeffs;
    }
    

    public Vector3[] GetPointsSecondaire()
    {
        float[] coeffs = GetCoeff();
        Vector3[] pointsSecondaires = new Vector3[coeffs.Length];
        for (int i = 0; i < coeffs.Length; i+=8)
        {
            for (int j = 0; j < 8; j++)
            {
                float t = j / 8f + i/8f;
                pointsSecondaires[i + j] = new Vector3(
                    coeffs[i] + coeffs[i + 1] * t + coeffs[i + 2] * t * t + coeffs[i + 3] * t * t * t,
                    coeffs[i + 4] + coeffs[i + 5] * t + coeffs[i + 6] * t * t + coeffs[i + 7] * t * t * t, 0);
            }
        }
        return pointsSecondaires;
    }
    */
}
