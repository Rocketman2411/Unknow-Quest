using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MathNet.Numerics.LinearAlgebra;
using Vector3 = UnityEngine.Vector3;

public class SplineGenerator : MonoBehaviour
{
    private List<Vector3> points;
    [SerializeField] private List<Vector3> controlPoints; 
    public List<float> GetCoeff()
    {
        List<float> composantesPointsControle = new List<float>();
        List<float> coeffs = new List<float>();

        for (int i = 0; i < controlPoints.Count * 2; i += 2)
        {
            composantesPointsControle.Add(controlPoints[i].x);
            composantesPointsControle.Add(controlPoints[i + 1].y);
        }
        var A = Matrix<float>.Build.DenseOfArray(ArrayTo2DimensionalArray(composantesPointsControle.ToArray()));
        var b = Vector<float>.Build.Dense(new float[] { 1, -2, 0 });
        var C = A.Solve(b);
        
        
        return coeffs;
    }

    private T[,] ArrayTo2DimensionalArray<T>(T[] t)
    {
        int dimensionalsize = Mathf.RoundToInt(Mathf.Sqrt(t.Length));
        T[,] tD2 = new T[dimensionalsize, dimensionalsize];
        for (int i = 0; i < dimensionalsize; i++)
        {
            for (int j = 0; j < dimensionalsize; j++)
            {
                tD2[i, j] = t[i * j + j];
            }
        }

        return tD2;
    }
    

    public Vector3[] GetPointsSecondaire()
    {
        List<float> coeffs = GetCoeff();
        Vector3[] pointsSecondaires = new Vector3[coeffs.Count];
        for (int i = 0; i < coeffs.Count; i+=8)
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
