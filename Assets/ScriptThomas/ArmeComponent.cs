using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class ArmeComponent : MonoBehaviour
{
    private GérerArmes armeManager;
    private int armeRemplacée1;
    private int armeRemplacée2;

    private void Awake()
    {
        armeManager = FindObjectOfType<GérerArmes>();
        
    }

    private void Update()
    {
        if (armeManager.estMultiJoueur && gameObject.transform.parent.gameObject.name == "Joueur2" && Input.GetKeyDown("r") && armeManager.armeLaPlusProche2 < 1)
        {
            armeRemplacée2 = armeManager.distanceArmes2.FindIndex(x =>  x >= armeManager.armeLaPlusProche2 - 0.001f && x <= armeManager.armeLaPlusProche2 + 0.001f);
            RemplacerArme2(armeRemplacée2);
        }
        if (gameObject.transform.parent.gameObject.name == "Joueur1" && Input.GetKeyDown("e") && armeManager.armeLaPlusProche1 < 2)
        {
            
            armeRemplacée1 = armeManager.distanceArmes1.FindIndex(x =>  x >= armeManager.armeLaPlusProche1 - 0.01f && x <= armeManager.armeLaPlusProche1 + 0.01f);
            Debug.Log($"nom1 = {armeManager.arme1.name}");
            RemplacerArme1(armeRemplacée1);
        }
    }
    
    public void RemplacerArme1(int nouvArme)
    {
        armeManager.objetArmes[nouvArme].transform.position = armeManager.arme1.gameObject.transform.position;
        armeManager.objetArmes[nouvArme].transform.SetParent(armeManager.joueur1.transform);
        armeManager.arme1.gameObject.transform.SetParent(armeManager.armesNonUtilisésParent.transform);
        armeManager.arme1 = armeManager.objetArmes[nouvArme].GetComponent<ArmeComponent>();
        Debug.Log($"nom2 = {armeManager.arme1.name}");
    }

    public void RemplacerArme2(int nouvArme)
    {
        armeManager.objetArmes[nouvArme].transform.position = armeManager.armesEnCoursUtilisation[1].gameObject.transform.position;
        armeManager.objetArmes[nouvArme].transform.parent = armeManager.joueurs[1].gameObject.transform;
        armeManager.armesEnCoursUtilisation[1].gameObject.transform.parent = armeManager.armesNonUtilisésParent.transform;
    }
}
