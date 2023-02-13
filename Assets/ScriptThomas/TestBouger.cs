using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBouger : MonoBehaviour
{
    private void Awake()
    {
        List<Vector3> points = new List<Vector3>();
        points.Add(new Vector3(1 ,1, 1));
        points.Add(new Vector3(1,2,1));
        points.Add(new Vector3(3,3,1));
        points.Add(new Vector3(4,4,1));
        gameObject.GetComponent<TestSplineGenerator>().controlPoints = points.ToArray();

    }

    private void Update()
    {
        
    }
}
