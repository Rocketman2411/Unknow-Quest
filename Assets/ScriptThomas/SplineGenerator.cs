using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;
using MathNet.Numerics.Interpolation;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using MathNet.Spatial.Euclidean;

public class SplineGenerator : MonoBehaviour
{
    [SerializeField] private List<Vector3> controlPoints;
    
    public Vector3 GetPointSpline(double distance)
    {
        var x = controlPoints.Select(p => p.x ).ToArray();
        var y = controlPoints.Select(p => p.y).ToArray();
        var z = controlPoints.Select(p => p.z).ToArray();
        var splineX = CubicSpline.InterpolateNatural(x, y);
        var splineY = CubicSpline.InterpolateNatural(x, y);
        var splineZ = CubicSpline.InterpolateNatural(x, z);
        
        var derivativeX = splineX.Differentiate();
        var derivativeY = splineY.Differentiate();
        var derivativeZ = splineZ.Differentiate();
        var tangent = new Vector3((float)derivativeX.(distance), (float)derivativeY.Interpolate(distance), (float)derivativeZ.Interpolate(distance)).normalized;
         return new Vector3((float)splineX.Interpolate(distance), (float)splineY.Interpolate(distance), (float)splineZ.Interpolate(distance)) + tangent;
    }
    /*
    public Vector3 GetSplinePoint(float distance)
    {
        GenerateSpline();
        var derivativeX = splineX.Differentiate();
        var derivativeY = splineY.Differentiate();
        var derivativeZ = splineZ.Differentiate();
        var tangent = new Vector3((float)derivativeX.Interpolate(distance), (float)derivativeY.Interpolate(distance), (float)derivativeZ.Interpolate(distance)).normalized;
        return new Vector3((float)splineX.Interpolate(distance), (float)splineY.Interpolate(distance), (float)splineZ.Interpolate(distance)) + tangent;
    }
*/
    /*
    public List<double> GetCoeff()
    {

        int n = controlPoints.Count;
        Vector3[] coeffs = new Vector3[n];
        Matrix<double> Ax = Matrix<double>.Build.DenseOfArray(new double[n-1,n-1]);
        for (int i = 0; i < n - 1; i++)
        {
            Ax[i, i] = 2 * controlPoints[i + 1].x - controlPoints[i].x;
            if (i > 0)
            {
                Ax[i, i - 1] = controlPoints[i + 1].x - controlPoints[i].x;
                Ax[i - 1, i] = controlPoints[i + 1].x - controlPoints[i].x;
            }
        }

        Vector<double>[] bx = new Vector<double>[n];
        for (int i = 0; i < n - 1; i++)
        {
            var P_0 = Vector<double>.Build.Dense(new double[] {controlPoints[i - 1].x,controlPoints[i - 1].y,controlPoints[i - 1].z} );
            var P_1 = Vector<double>.Build.Dense(new double[] {controlPoints[i].x,controlPoints[i].y,controlPoints[i].z} );
            var P_2 = Vector<double>.Build.Dense(new double[] {controlPoints[i + 1].x,controlPoints[i + 1].y,controlPoints[i + 1].z} );
            double x_0 = controlPoints[i - 1].x;
            double x_1 = controlPoints[i].x;
            double x_2 = controlPoints[i + 1].x;

            var delta_1 = (P_1 - P_0) / (x_1 - x_0);
            var delta_2 = (P_2 - P_1) / (x_2 - x_1);

            bx[i] = (delta_2.Subtract(delta_1));
        }
        Matrix<double> Ay = Matrix<double>.Build.DenseOfArray(new double[n-1,n-1]);
        for (int i = 0; i < n - 1; i++)
        {
            Ay[i, i] = 2 * controlPoints[i + 1].y - controlPoints[i].y;
            if (i > 0)
            {
                Ay[i, i - 1] = controlPoints[i + 1].y - controlPoints[i].y;
                Ay[i - 1, i] = controlPoints[i + 1].y - controlPoints[i].y;
            }
        }

        Vector<double>[] by = new Vector<double>[n];
        for (int i = 0; i < n - 1; i++)
        {
            var P_0 = Vector<double>.Build.Dense(new double[] {controlPoints[i - 1].x,controlPoints[i - 1].y,controlPoints[i - 1].z} );
            var P_1 = Vector<double>.Build.Dense(new double[] {controlPoints[i].x,controlPoints[i].y,controlPoints[i].z} );
            var P_2 = Vector<double>.Build.Dense(new double[] {controlPoints[i + 1].x,controlPoints[i + 1].y,controlPoints[i + 1].z} );
            double y_0 = controlPoints[i - 1].y;
            double y_1 = controlPoints[i].y;
            double y_2 = controlPoints[i + 1].y;

            var delta_1 = (P_1 - P_0) / (y_1 - y_0);
            var delta_2 = (P_2 - P_1) / (y_2 - y_1);

            by[i] = (delta_2.Subtract(delta_1));
        }
        Matrix<double> Az = Matrix<double>.Build.DenseOfArray(new double[n-1,n-1]);
        for (int i = 0; i < n - 1; i++)
        {
            Az[i, i] = 2 * controlPoints[i + 1].z - controlPoints[i].z;
            if (i > 0)
            {
                Az[i, i - 1] = controlPoints[i + 1].z - controlPoints[i].z;
                Az[i - 1, i] = controlPoints[i + 1].z - controlPoints[i].z;
            }
        }

        Vector<double>[] bz = new Vector<double>[n];
        for (int i = 0; i < n - 1; i++)
        {
            var P_0 = Vector<double>.Build.Dense(new double[] {controlPoints[i - 1].x,controlPoints[i - 1].y,controlPoints[i - 1].z} );
            var P_1 = Vector<double>.Build.Dense(new double[] {controlPoints[i].x,controlPoints[i].y,controlPoints[i].z} );
            var P_2 = Vector<double>.Build.Dense(new double[] {controlPoints[i + 1].x,controlPoints[i + 1].y,controlPoints[i + 1].z} );
            double z_0 = controlPoints[i - 1].z;
            double z_1 = controlPoints[i].z;
            double z_2 = controlPoints[i + 1].z;

            var delta_1 = (P_1 - P_0) / (z_1 - z_0);
            var delta_2 = (P_2 - P_1) / (z_2 -z_1);

            bz[i] = (delta_2.Subtract(delta_1));
        }
        
        var solutionX = new Vector<double>[bx.Length];
        for (int i = 0; i < bx.Length; i++)
        {
            solutionX[i] = Ax.Solve(bx[i]);
        }
        var solutionY = new Vector<double>[by.Length];
        for (int i = 0; i < bz.Length; i++)
        {
            solutionY[i] = Ay.Solve(by[i]);
        }
        var solutionZ = new Vector<double>[bz.Length];
        for (int i = 0; i < bz.Length; i++)
        {
            solutionZ[i] = Az.Solve(bz[i]);
        }

        Vector<double>[] coefficientsX = new Vector<double>[n];
        coefficientsX[0] = Vector<double>.Zero;
        for (int i = 0; i < UPPER; i++)
        {
            
        }

        return coeffs;
    }
    */
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
    
/*
    public Vector3[] GetPointsSecondaire()
    {
        List<double> coeffs = GetCoeff();
        Vector3[] pointsSecondaires = new Vector3[coeffs.Count];
        for (int i = 0; i < coeffs.Count; i+=12)
        {
            for (int j = 0; j < 8; j++)
            {
                float t = j / 8f + i/8f;
                pointsSecondaires[i + j] = new Vector3(
                    (float)(coeffs[i] + coeffs[i + 1] * t + coeffs[i + 2] * t * t + coeffs[i + 3] * t * t * t),
                    (float)(coeffs[i + 4] + coeffs[i + 5] * t + coeffs[i + 6] * t * t + coeffs[i + 7] * t * t * t), 
                    (float)(coeffs[i + 8] + coeffs[i + 9] * t + coeffs[i + 10] * t * t + coeffs[i + 11] * t * t * t));
            }
        }
        return pointsSecondaires;
    }
    */
}
