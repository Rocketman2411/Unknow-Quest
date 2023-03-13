using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;

public class TestSpline : MonoBehaviour
{
    public Vector3[] controlPointsPositions;
    public int resolution = 10;
    public bool loop = false;
    public float speed = 1f;

    private SplineGenerator spline;
    private float t = 0f;

    void Start() 
    {
        spline = gameObject.AddComponent<SplineGenerator>();
        spline.pointsControl = controlPointsPositions;
        spline.res = resolution;
        spline.loop = loop;
    }

    void Update() 
    {
        t += speed * Time.deltaTime;
        if (t > 1f && loop) 
            t -= 1f;
        gameObject.transform.position = spline.GetPoint(t);
        gameObject.transform.LookAt(spline.GetPoint(t + 0.1f));
    }
}
