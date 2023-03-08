using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Numerics;
using Vector3 = UnityEngine.Vector3;

public class TestSpline : MonoBehaviour
{
    [SerializeField] private double distance = 1;
    private SplineGenerator _splineGenerator;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _splineGenerator = FindObjectOfType<SplineGenerator>();
    }

    private void Update()
    {
        
        float x = Vector3.MoveTowards(gameObject.transform.position, _splineGenerator.GetPointSpline(distance), 10).x;
        float y = Vector3.MoveTowards(gameObject.transform.position, _splineGenerator.GetPointSpline(distance), 10).y;
        float z = Vector3.MoveTowards(gameObject.transform.position, _splineGenerator.GetPointSpline(distance), 10).z;
        Debug.Log($"x = {x}, y = {y}, z = {z} ");
        /*
        float x = transform.position.x;
        float y =transform.position.y;
        float z = transform.position.z;*/
        transform.position = new Vector3(x, y, z);
        //Debug.Log($"x: {x}, y = {y}, z = {z}");

    }
}
