using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class ArmeComponent : MonoBehaviour
{
    private List<ArmeComponent> armes;
    private List<GameObject> objetArmes;
    private ArmeComponent[] armesEnCoursUtilisation;
    
    [SerializeField]private int armeRemplace1;
    [SerializeField] private int armeRemplace2;
    
    private List<PlayerComponent> joueurs;
    private List<float> distanceArmes1;
    private List<float> distanceArmes2;
    public GameObject parentArmeDiscartée;
    private void Awake()
    {
        armes = FindObjectsOfType<ArmeComponent>().ToList();
        foreach (var arme in armes)
            objetArmes.Add(arme.gameObject);
        joueurs = FindObjectsOfType<PlayerComponent>().ToList();
        distanceArmes1 = new List<float>();
        distanceArmes2 = new List<float>();
    }

    private void Update()
    {
        armesEnCoursUtilisation = new ArmeComponent[2];
        armesEnCoursUtilisation[0] = joueurs[0].GetComponentInChildren<ArmeComponent>();
        armesEnCoursUtilisation[1] = joueurs[1].GetComponentInChildren<ArmeComponent>();
        for (int i = 0; i < objetArmes.Count; i++)
        {
            distanceArmes1.Add(Mathf.Sqrt(Mathf.Pow(objetArmes[i].transform.position.x- joueurs[0].transform.position.x,2) +
                               Mathf.Pow(objetArmes[i].transform.position.y- joueurs[0].transform.position.y,2) +
                               Mathf.Pow(objetArmes[i].transform.position.z- joueurs[0].transform.position.z,2)));
        }
        float armeLaPlusProche1 = Mathf.Min(distanceArmes1.ToArray());
        armeRemplace1 = distanceArmes1.FindIndex(x =>  x >= armeLaPlusProche1 - 0.001f && x <= armeLaPlusProche1 + 0.001f);
        
        for (int i = 0; i < objetArmes.Count; i++)
        {
            distanceArmes2.Add(Mathf.Sqrt(Mathf.Pow(objetArmes[i].transform.position.x- joueurs[1].transform.position.x,2) +
                                          Mathf.Pow(objetArmes[i].transform.position.y- joueurs[1].transform.position.y,2) +
                                          Mathf.Pow(objetArmes[i].transform.position.z- joueurs[1].transform.position.z,2)));
        }
        float armeLaPlusProche2 = Mathf.Min(distanceArmes2.ToArray());
        armeRemplace2 = distanceArmes2.FindIndex(x =>  x >= armeLaPlusProche2 - 0.001f && x <= armeLaPlusProche2 + 0.001f);
        
        GameObject[] os = FindObjectsOfType<GameObject>();
        
        foreach (var o in os)
        {
            if (o.layer == 10)
            {
                parentArmeDiscartée = o;
            }
        }
        
        if(Input.GetKeyDown("e") && armeLaPlusProche1 < 2 )
            RemplacerArme1(armeRemplace1);
        if(Input.GetKeyDown("e") && armeLaPlusProche2 < 2)
            RemplacerArme2(armeRemplace2);
    }



    public void RemplacerArme1(int nouvArme)
    {
        objetArmes[nouvArme].transform.position = armesEnCoursUtilisation[0].gameObject.transform.position;
        objetArmes[nouvArme].transform.parent = joueurs[0].gameObject.transform;
        armesEnCoursUtilisation[0].gameObject.transform.parent = parentArmeDiscartée.transform;
    }

    public void RemplacerArme2(int nouvArme)
    {
        objetArmes[nouvArme].transform.position = armesEnCoursUtilisation[1].gameObject.transform.position;
        objetArmes[nouvArme].transform.parent = joueurs[1].gameObject.transform;
        armesEnCoursUtilisation[1].gameObject.transform.parent = parentArmeDiscartée.transform;
    }
}
