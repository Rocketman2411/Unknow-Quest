using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;
using Matrix4x4 = UnityEngine.Matrix4x4;

using Vector3 = UnityEngine.Vector3;

public class SplineGenerator : MonoBehaviour
{
    private List<Vector3> points;
    private List<Vector3> controlPoints; 
    public float[] GetCoeff()
    {
        List<float> composantesPointsControle = new List<float>();
        controlPoints = new List<Vector3>();
        for (int i = 0; i < controlPoints.Count * 2; i += 2)
        {
            composantesPointsControle.Add(controlPoints[i].x);
            composantesPointsControle.Add(controlPoints[i + 1].y);
        }
        var A = Matrix.Build.DenseOfArray(new double[,] {
            { 3, 2, -1 },
            { 2, -2, 4 },
            { -1, 0.5, -1 }
        });
        var b = Vector<double>.Build.Dense(new double[] { 1, -2, 0 });
        var x = A.Solve(b);
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
    
}
