using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GérerArmes : MonoBehaviour
{
    public GameObject armesNonUtilisésParent;
    public bool estMultiJoueur;
    public ArmeComponent[] armesEnCoursUtilisation;
    public List<float> distanceArmes2;
    public List<float> distanceArmes1;
    public PlayerComponent[] joueurs;
    public PlayerComponent joueur1;
    public PlayerComponent joueur2;
    public List<GameObject> objetArmes;
    public List<ArmeComponent> armes;
    public Vector3 positionJoueur1;
    public Vector3 positionJoueur2;
    public ArmeComponent arme1;
    public ArmeComponent arme2;
    
    private void Awake()
    {
        armesNonUtilisésParent = new GameObject("ArmesNonUtilisées");
        armesNonUtilisésParent.transform.position = new Vector3(0, 0, 0);
        estMultiJoueur = SceneManager.GetActiveScene().path.Contains("Coop");
        if (estMultiJoueur)
        {
            armesEnCoursUtilisation = new ArmeComponent[2];
            
            distanceArmes2 = new List<float>();
            joueurs = FindObjectsOfType<PlayerComponent>();
            joueur1 = joueurs[0];
            joueur2 = joueurs[1];
        }
        else
        {
            armesEnCoursUtilisation = new ArmeComponent[1];
            joueur1 = FindObjectOfType<PlayerComponent>();
        }
        objetArmes = new List<GameObject>();
        armes = FindObjectsOfType<ArmeComponent>().ToList();
        foreach (var arme in armes)
        {
            objetArmes.Add(arme.gameObject);
            if (estMultiJoueur)
            {
                if (!(arme.transform.parent.gameObject == joueur1.gameObject || arme.transform.parent.gameObject == joueur2.gameObject))
                {
                    arme.transform.parent = armesNonUtilisésParent.transform;
                }
            }
            else
            {
                if(arme.transform.parent.gameObject != joueur1.gameObject)
                {
                    arme.transform.parent = armesNonUtilisésParent.transform;
                }
            }
        }
        
        distanceArmes1 = new List<float>();
    }
    public float armeLaPlusProche1;
    public float armeLaPlusProche2; 
    private void Update()
    {
        
        positionJoueur1 = joueur1.transform.position;
        arme1 = joueur1.GetComponentInChildren<ArmeComponent>();
        for (int i = 0; i < objetArmes.Count; i++)
        {
            distanceArmes1.Add(CalculerDistance1(objetArmes[i]));
        }
        armeLaPlusProche1 = Mathf.Min(distanceArmes1.ToArray());
        
        if (estMultiJoueur)
        {
            arme2 = joueur2.GetComponentInChildren<ArmeComponent>(); 
            positionJoueur2 = joueur2.transform.position;
            
            for (int i = 0; i < objetArmes.Count; i++)
            {
                distanceArmes2.Add(CalculerDistance2(objetArmes[i]));
            }
            armeLaPlusProche2 = Mathf.Min(distanceArmes2.ToArray());
            
        }
    }
    float CalculerDistance1(GameObject g)
    {
        return Mathf.Sqrt(Mathf.Pow(g.transform.position.x - positionJoueur1.x, 2) +
                          Mathf.Pow(g.transform.position.y - positionJoueur1.y, 2) +
                          Mathf.Pow(g.transform.position.z - positionJoueur1.z, 2));
    }
    float CalculerDistance2(GameObject g)
    {
        return Mathf.Sqrt(Mathf.Pow(g.transform.position.x - positionJoueur2.x, 2) +
                          Mathf.Pow(g.transform.position.y - positionJoueur2.y, 2) +
                          Mathf.Pow(g.transform.position.z - positionJoueur2.z, 2));
    }
}
