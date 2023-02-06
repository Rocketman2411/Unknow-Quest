using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManagerComponent : MonoBehaviour
{
    private LifeComponent life = new LifeComponent();
    private Vector3 distanceEnnemiPlusProche;
    private List<GameObject> ennemis;
    private EnnemiManager _ennemiManager;

    private void Awake()
    {
        _ennemiManager = new EnnemiManager();
        distanceEnnemiPlusProche = new Vector3();
        ennemis = _ennemiManager.ennemis;
        _ennemiManager.distanceEnnemis.Max();
    }

    private void Update()
    {
        // sert à regénérer quand player assez loin d'un ennemi
        if (_ennemiManager.distanceEnnemiPlusProche >= 20
            && life.vie < gameObject.layer * 10)
            life.vie++;
        
        if (life.vie == 0)
            Destroy(gameObject);
    }
}
