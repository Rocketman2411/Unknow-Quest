using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnnemiScriptComponent : MonoBehaviour
{
    [SerializeField]public float life;
    [SerializeField]public float attaque;

    [SerializeField]private Vector3 positionEnnemi;
    private List<PlayerComponent> joueurs;
    private int difficulté;
    private bool estMultijoueur;

    private void Awake()
    {
        difficulté = FindObjectOfType<EnnemyManager>().difficulté;
        joueurs = FindObjectsOfType<PlayerComponent>().ToList();
        if (difficulté == 3)
        {
            attaque *= 1.2f;
        }

        if (joueurs.Count != 1)
        {
            estMultijoueur = true;
        }
    }

    private void Update()
    {
        positionEnnemi = transform.position;
        if(life <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint c = collision.GetContact(0);
        if (c.otherCollider.gameObject.layer == 6 && c.otherCollider.gameObject.layer == 7)
            c.otherCollider.gameObject.GetComponent<PlayerComponent>().life -= attaque;
    }

    public float CalculerDistanceSolo()
    {
        float distanceAvecJoueur1 = Mathf.Sqrt(Mathf.Pow(positionEnnemi.x - joueurs[0].position.x, 2) +
                                               Mathf.Pow(positionEnnemi.y - joueurs[0].position.y, 2) +
                                               Mathf.Pow(positionEnnemi.z - joueurs[0].position.z, 2));
        return distanceAvecJoueur1;
    }
    public float[] CalculerDistanceCoop()
    {
        float distanceAvecJoueur1 = Mathf.Sqrt(Mathf.Pow(positionEnnemi.x - joueurs[0].position.x, 2) +
                                    Mathf.Pow(positionEnnemi.y - joueurs[0].position.y, 2) +
                                    Mathf.Pow(positionEnnemi.z - joueurs[0].position.z, 2));
        float distanceAvecJoueur2 = Mathf.Sqrt(Mathf.Pow(positionEnnemi.x - joueurs[1].position.x, 2) +
                                              Mathf.Pow(positionEnnemi.y - joueurs[1].position.y, 2) +
                                              Mathf.Pow(positionEnnemi.z - joueurs[1].position.z, 2));
        float[] distances = new float[2] { distanceAvecJoueur1, distanceAvecJoueur2 };
        return distances;
    }
}
