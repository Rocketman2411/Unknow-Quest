using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemiManager : MonoBehaviour
{
    public List<GameObject> ennemis { get; set; }
    private PlayerManagerComponent _playerManagerComponent;
    public float[] distanceEnnemis;
    public float distanceEnnemiPlusProche;
    private void Awake()
    {
        ennemis = new List<GameObject>();
        
        for (int i = 0; i < gameObject.transform.hierarchyCount; i++)
        {
            ennemis.Add(transform.GetChild(i).gameObject);
        }

        _playerManagerComponent = gameObject.AddComponent<PlayerManagerComponent>();
    }

    private void Update()
    {
         distanceEnnemis = new float[ennemis.Count];
        for (int i = 0; i < ennemis.Count; i++)
        {
            distanceEnnemis[i] = Mathf.Sqrt(
                Mathf.Pow(ennemis[i].transform.position.x - _playerManagerComponent.transform.position.x, 2) +
                Mathf.Pow(ennemis[i].transform.position.y - _playerManagerComponent.transform.position.y, 2) +
                Mathf.Pow(ennemis[i].transform.position.z - _playerManagerComponent.transform.position.z, 2));
        }

        distanceEnnemiPlusProche = Mathf.Max(distanceEnnemis);

    }
}
