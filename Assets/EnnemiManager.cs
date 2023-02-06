using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemiManager : MonoBehaviour
{
    public List<GameObject> ennemis { get; set; }
    private PlayerManagerComponent _playerManagerComponent;

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
        Vector3[] distanceEnnemis = new Vector3()[ennemis.Count];
        GameObject ennemiPlusproche = new GameObject();
        for (int i = 0; i < ennemis.Count; i++)
        {
            distanceEnnemis[i] = ennemis[i].gameObject.transform.position -
                                 _playerManagerComponent.gameObject.transform.position;
        }
    }
}
