using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemiManager : MonoBehaviour
{
    private List<GameObject> ennemis;

    private void Awake()
    {
        ennemis = new List<GameObject>();
        
        for (int i = 0; i < gameObject.transform.hierarchyCount; i++)
        {
            ennemis.Add(transform.GetChild(i).gameObject);
        }



    }
}
