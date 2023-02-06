using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerComponent : MonoBehaviour
{
    private LifeComponent life = new LifeComponent();
    private Vector3 distanceEnnemi;

    private void Awake()
    {
        distanceEnnemi = new Vector3();
    }

    private void Update()
    {
        if (life.vie != gameObject.layer * 10)
        {
            float time = 0;
            time += Time.deltaTime;
            gameObject.layer = 6;
        }

        if (life.vie != gameObject.layer * 10) // vie regénère avec le temps
        {
            life.vie++;
            
        }
    }
}
