using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;

public class TestSpline : MonoBehaviour
{
    public Vector3[] pointsControlesTest;
    public int res = 10;
    public bool loop = false;
    public float vitesse = 1f;
    private SplineGenerator spline;
    private float t = 0f;
    void Awake() 
    {
        spline = gameObject.GetComponent<SplineGenerator>();
        spline.pointsControles = pointsControlesTest;
        spline.res = res;
        spline.loop = loop;
    }
    void Update() 
    {
        t += vitesse * Time.deltaTime;
        if (loop && t > 1)
            t = 0f;
        gameObject.transform.position = spline.TrouverPoint(t);
        gameObject.transform.LookAt(spline.TrouverPoint(t + 0.1f));
    }
}
