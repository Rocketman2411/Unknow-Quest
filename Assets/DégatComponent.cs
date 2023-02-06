using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DégatComponent : MonoBehaviour
{
    public int dégat { get; set; }
    private LifeComponent life;

    private void Awake()
    {
        dégat = gameObject.layer;
        life = gameObject.GetComponent<LifeComponent>();
    }

    void PrendreDégat(int dégat) => life.vie -= dégat;


}
