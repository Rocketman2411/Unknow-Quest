using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyManager : MonoBehaviour
{
    private List<GameObject> ennemis;
    
    [SerializeField] public int difficulté = 1;
    private List<float> distancesAvecJoueur1;
    private List<float> distancesAvecJoueur2;

    private void Awake()
    {
        distancesAvecJoueur1 = new List<float>();
        distancesAvecJoueur2 = new List<float>();
        ennemis = new List<GameObject>();
        
        foreach (var ennemi in FindObjectsOfType<EnnemiScriptComponent>())
        {
            ennemis.Add(ennemi.gameObject);
            distancesAvecJoueur1.Add(ennemi.CalculerDistanceAvecPlayers()[0]);
            distancesAvecJoueur2.Add(ennemi.CalculerDistanceAvecPlayers()[1]);
        }
    }

    private void Update()
    {
        List<GameObject> ennemisÀJour = ennemis.FindAll(x => x.GetComponent<EnnemiScriptComponent>().life > 0);
        List<float> distances1ÀJour = new List<float>();
        List<float> distances2ÀJour = new List<float>();
        for (int i = 0; i < ennemisÀJour.Count; i++)
        {
            distances1ÀJour.Add(ennemisÀJour[i].GetComponent<EnnemiScriptComponent>().CalculerDistanceAvecPlayers()[0]);
            distances2ÀJour.Add(ennemisÀJour[i].GetComponent<EnnemiScriptComponent>().CalculerDistanceAvecPlayers()[1]);
        }
    }
}
