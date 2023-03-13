using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyManager : MonoBehaviour
{
    public List<EnnemiScriptComponent> ennemis;
    public List<EnnemiScriptComponent> ennemisÀJour;
    
    [SerializeField] public int difficulté = 1;
    public List<float> distancesAvecJoueur1;
    public List<float> distancesAvecJoueur2;
    private bool estmultijoueur;
    private void Awake()
    {
        distancesAvecJoueur1 = new List<float>();
        distancesAvecJoueur2 = new List<float>();
        ennemis = new List<EnnemiScriptComponent>();
        if (FindObjectsOfType<PlayerComponent>().Length != 1)
        {
            estmultijoueur = true;
        }

        if (estmultijoueur)
        {
            foreach (var ennemi in FindObjectsOfType<EnnemiScriptComponent>())
            {
                ennemis.Add(ennemi);
                distancesAvecJoueur1.Add(ennemi.CalculerDistanceCoop()[0]);
                distancesAvecJoueur2.Add(ennemi.CalculerDistanceCoop()[1]);
            }
        }
        else
        {
            foreach (var ennemi in FindObjectsOfType<EnnemiScriptComponent>())
            {
                ennemis.Add(ennemi);
                distancesAvecJoueur1.Add(ennemi.CalculerDistanceSolo());
            }
        }
    }

    private void Update()
    {
        ennemisÀJour = ennemis.FindAll(x => x.GetComponent<EnnemiScriptComponent>().life > 0);
        List<float> distances1ÀJour = new List<float>();
        List<float> distances2ÀJour = new List<float>();
        if (estmultijoueur)
        {
            for (int i = 0; i < ennemisÀJour.Count; i++)
            {
                distances1ÀJour.Add(ennemisÀJour[i].GetComponent<EnnemiScriptComponent>().CalculerDistanceCoop()[0]);
                distances2ÀJour.Add(ennemisÀJour[i].GetComponent<EnnemiScriptComponent>().CalculerDistanceCoop()[1]);
            }
        }
        else
        {
            for (int i = 0; i < ennemisÀJour.Count; i++)
            {
                distances1ÀJour.Add(ennemisÀJour[i].GetComponent<EnnemiScriptComponent>().CalculerDistanceSolo());
            }
        }
    }
}
