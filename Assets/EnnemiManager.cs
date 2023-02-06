using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemiManager : MonoBehaviour
{
    public List<GameObject> ennemis { get; set; }
    private PlayerManagerComponent _playerManagerComponent;
    public List<float> distanceEnnemis;
    public float distanceEnnemiPlusProche;
    private Vector3 positionPlayer;
    private int[] vieEnnemis;
    private void Awake()
    {
        ennemis = new List<GameObject>();
        
        for (int i = 0; i < gameObject.transform.hierarchyCount; i++)
        {
            ennemis.Add(transform.GetChild(i).gameObject);
        }

        _playerManagerComponent = gameObject.AddComponent<PlayerManagerComponent>();
         positionPlayer = _playerManagerComponent.transform.position;
         
         vieEnnemis = new int[ennemis.Count];
         for (int i = 0; i < vieEnnemis.Length; i++)
         {
             vieEnnemis[i] = ennemis[i].gameObject.GetComponent<LifeComponent>().vie;
         }
    }

    private void Update()
    {
        distanceEnnemis = new List<float>();
        for (int i = 0; i < ennemis.Count; i++)
        {
            distanceEnnemis.Add(Mathf.Sqrt(
                Mathf.Pow(ennemis[i].transform.position.x - positionPlayer.x, 2) +
                Mathf.Pow(ennemis[i].transform.position.y - positionPlayer.y, 2) +
                Mathf.Pow(ennemis[i].transform.position.z - positionPlayer.z, 2)));  
        }

        for (int i = 0; i < ennemis.Count; i++)
        {
            if (vieEnnemis[0] <= 0)
            {
                Destroy(ennemis[i].gameObject);
                ennemis.RemoveAt(i);
                distanceEnnemis.RemoveAt(i);
            }
        }
        vieEnnemis = vieEnnemis.Where(x => x != 0).ToArray();

        distanceEnnemiPlusProche = Mathf.Max(distanceEnnemis.ToArray());
    }
}
