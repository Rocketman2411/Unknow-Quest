using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class ArmeComponent : MonoBehaviour
{
    private List<ArmeComponent> armes;
    private List<GameObject> objetArmes;
    private ArmeComponent[] armesEnCoursUtilisation;
    private ArmeComponent arme1;
    private ArmeComponent arme2;
    private GameObject armesNonUtilisésParent;
    private int armeRemplace1;
    private int armeRemplace2;

    private PlayerComponent joueur1;
    private PlayerComponent joueur2;
    private List<PlayerComponent> joueurs;
    private List<float> distanceArmes1;
    private List<float> distanceArmes2;
    private GameObject parentArmeDiscartée;
    private bool estMultiJoueur;
    

    private void Update()
    {
        float armeLaPlusProche1;
        float armeLaPlusProche2;
        Vector3 positionJoueur1 = joueur1.transform.position;
        arme1 = joueur1.GetComponentInChildren<ArmeComponent>();
        for (int i = 0; i < objetArmes.Count; i++)
        {
            distanceArmes1.Add(Mathf.Sqrt(Mathf.Pow(objetArmes[i].transform.position.x- positionJoueur1.x,2) +
                               Mathf.Pow(objetArmes[i].transform.position.y- positionJoueur1.y,2) +
                               Mathf.Pow(objetArmes[i].transform.position.z- positionJoueur1.z,2)));
        }
        armeLaPlusProche1 = Mathf.Min(distanceArmes1.ToArray());
        if (Input.GetKeyDown("e") && armeLaPlusProche1 < 1)
        {
            
            armeRemplace1 = distanceArmes1.FindIndex(x =>  x >= armeLaPlusProche1 - 0.001f && x <= armeLaPlusProche1 + 0.001f);
            RemplacerArme1(armeRemplace1);
        }
        if (estMultiJoueur)
        {
            arme2 = joueur2.GetComponentInChildren<ArmeComponent>();
            Vector3 positionJoueur2 = joueur2.transform.position;
            
            for (int i = 0; i < objetArmes.Count; i++)
            {
                distanceArmes2.Add(Mathf.Sqrt(Mathf.Pow(objetArmes[i].transform.position.x- positionJoueur2.x,2) +
                                              Mathf.Pow(objetArmes[i].transform.position.y- positionJoueur2.y,2) +
                                              Mathf.Pow(objetArmes[i].transform.position.z- positionJoueur2.z,2)));
            }
            armeLaPlusProche2 = Mathf.Min(distanceArmes2.ToArray());
            if (Input.GetKeyDown("r") && armeLaPlusProche2 < 1)
            {
                armeRemplace2 = distanceArmes2.FindIndex(x =>  x >= armeLaPlusProche2 - 0.001f && x <= armeLaPlusProche2 + 0.001f);
                RemplacerArme2(armeRemplace2);
            }
        }
        
        GameObject[] os = FindObjectsOfType<GameObject>();
        
        foreach (var o in os)
        {
            if (o.layer == 10)
            {
                parentArmeDiscartée = o;
            }
        }
    }

    //float CalculerDistance()
    //{
        
    //}
    public void RemplacerArme1(int nouvArme)
    {
        objetArmes[nouvArme].transform.position = armesEnCoursUtilisation[0].gameObject.transform.position;
        objetArmes[nouvArme].transform.parent = joueur1.transform;
        armesEnCoursUtilisation[0].gameObject.transform.parent = parentArmeDiscartée.transform;
    }

    public void RemplacerArme2(int nouvArme)
    {
        objetArmes[nouvArme].transform.position = armesEnCoursUtilisation[1].gameObject.transform.position;
        objetArmes[nouvArme].transform.parent = joueurs[1].gameObject.transform;
        armesEnCoursUtilisation[1].gameObject.transform.parent = parentArmeDiscartée.transform;
    }
}
