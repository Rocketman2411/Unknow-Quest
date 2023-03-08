using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;
using MathNet.Numerics.Differentiation;
using MathNet.Numerics.Interpolation;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using MathNet.Spatial.Euclidean;

public class SplineGenerator : MonoBehaviour
{
    public List<Vector3> ptsControle;
    private List<Vector3> ptsSpline;
    
    private List<float> ptsSplineX;
    private List<float> coeffsX;
    
    private List<float> ptsSplineY;
    private List<float> coeffsY;
    
    private List<float> ptsSplineZ;
    private List<float> coeffsz;

    /*private void CréerListePointsControle()
    {
        for (int i = 0; i < 10; i++)
        {
            ptsControle.Add(new Vector3(Mathf.Pow(i,2),Mathf.Pow(i ,2),Mathf.Pow(i ,2))); // À changer
        }
    }
    */
/*
    public List<Vector3> GetPointsSecondaire()
    {
        List<float> coeffs = GetCoeffs();
        Vector3[] pointsSecondaires = new Vector3[coeffs.Count];
        for (int i = 0; i < coeffs.Count; i+=12)
        {
            for (int j = 0; j < 12; j++)
            {
                float t = j / 12f + i/12f;
                pointsSecondaires[i + j] = new Vector3(
                    (float)(coeffs[i] + coeffs[i + 1] * t + coeffs[i + 2] * t * t + coeffs[i + 3] * t * t * t),
                    (float)(coeffs[i + 4] + coeffs[i + 5] * t + coeffs[i + 6] * t * t + coeffs[i + 7] * t * t * t), 
                    (float)(coeffs[i + 8] + coeffs[i + 9] * t + coeffs[i + 10] * t * t + coeffs[i + 11] * t * t * t));
            }
        }
        return pointsSecondaires.ToList();
    }
    */
    public Vector3 GetPointSpline(double distance)
    {
        
        double[] x0 = ptsControle.Select(p => (double)p.x).ToArray();
        double[] y0 = ptsControle.Select(p => (double)p.y).ToArray();
        double[] z0 = ptsControle.Select(p => (double)p.z).ToArray();
        var splineX = CubicSpline.InterpolateNatural(x0, y0);
        var splineY = CubicSpline.InterpolateNatural(y0, z0);
        var splineZ = CubicSpline.InterpolateNatural(x0, z0);
        
        
        var derivativeX = splineX.Differentiate(distance);
        var derivativeY = splineY.Differentiate(distance);
        var derivativeZ = splineZ.Differentiate(distance);
        
        Vector3 tangent = new Vector3((float)derivativeX, (float)derivativeY, (float)derivativeZ).normalized;
        return new Vector3((float)splineX.Interpolate(distance), (float)splineY.Interpolate(distance), (float)splineZ.Interpolate(distance)) + tangent;
    }
}
