using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerComponent : MonoBehaviour
{
    private LifeComponent life = new LifeComponent();
    private Vector3 distanceEnnemi;
    private List<GameObject> ennemis;
    private EnnemiManager _ennemiManager;

    private void Awake()
    {
        _ennemiManager = new EnnemiManager();
        distanceEnnemi = new Vector3();
        ennemis = _ennemiManager.ennemis;
    }

    private void Update()
    {
        // sert à regénérer quand player assez loin d'un ennemi
        if (Mathf.Sqrt(Mathf.Pow(distanceEnnemi.x,2) + Mathf.Pow(distanceEnnemi.y,2) + Mathf.Pow(distanceEnnemi.z,2)) >= 10
            && life.vie < gameObject.layer * 10)
            life.vie++;
        if (life.vie == 0)
            Destroy(gameObject);
    }
}
