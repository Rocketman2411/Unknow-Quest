using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GérerArmes : MonoBehaviour
{
    private GameObject armesNonUtilisésParent;
    private bool estMultiJoueur;
    private ArmeComponent[] armesEnCoursUtilisation;
    private List<float> distanceArmes2;
    private List<float> distanceArmes1;
    private PlayerComponent[] joueurs;
    private PlayerComponent joueur1;
    private PlayerComponent joueur2;
    private List<GameObject> objetArmes;
    private List<ArmeComponent> armes;
    
    private void Awake()
    {
        armesNonUtilisésParent = new GameObject();
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
            if (arme.transform.parent == null)
            {
                arme.transform.parent = armesNonUtilisésParent.transform;
            }
        }
        
        distanceArmes1 = new List<float>();
    }

    private void Update()
    {
        
    }
}
