using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    [SerializeField]public int life;
    [SerializeField]public int attaque;
    [SerializeField]public Vector3 position;
    public Vector3 positionDépart;
    private List<PlayerComponent> listeJoueur;
    public List<GameObject> listeJoueurs2;

    private void Awake()
    {
        position = positionDépart = transform.position;
        listeJoueur = FindObjectsOfType<PlayerComponent>().ToList();
        for (int i = 0; i < listeJoueur.Count; i++)
        {
            listeJoueurs2.Add(listeJoueur[i].gameObject);
        }
    }

    private void Update()
    {
        position = transform.position;
        if(life <= 0)
            RespawnerAprèsMort();
    }
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint c = collision.GetContact(0);
        if (c.otherCollider.gameObject.layer == 8)
            c.otherCollider.gameObject.GetComponent<EnnemiScriptComponent>().life -= attaque;
    }
    
    void RespawnerAprèsMort()
       => transform.position = positionDépart;
}
