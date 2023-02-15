using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBouger : MonoBehaviour
{
    public TestSplineGenerator spline;

    public float duration;
    private float progress;

    private void Update()
    {
        progress += Time.deltaTime / duration;
        transform.position = spline.GetPoint(progress);
    }
    
}
