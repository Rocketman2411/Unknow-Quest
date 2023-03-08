using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerComponent : MonoBehaviour
{
    [SerializeField]public float life;
    [SerializeField]public float attaque;
    [SerializeField]public Vector3 position;
    public Vector3 positionDépart;
    private List<PlayerComponent> listeJoueur;
    public List<GameObject> listeJoueurs2;
    public bool[] estEnModeAttaque;
    public List<EnnemiScriptComponent> ennemis;
    public EnnemiScriptComponent ennemiPlusProche;
    private int difficulté;
    public EnnemyManager e;
    private string currentLevel;

    private void Awake()
    {
        ennemis = FindObjectsOfType<EnnemiScriptComponent>().ToList();
        position = positionDépart = transform.position;
        listeJoueur = FindObjectsOfType<PlayerComponent>().ToList();
        for (int i = 0; i < listeJoueur.Count; i++)
        {
            listeJoueurs2.Add(listeJoueur[i].gameObject);
        }

        e = FindObjectOfType<EnnemyManager>();
        currentLevel = SceneManager.GetActiveScene().name;
    }

    public void RegarderEnnemiPlusProche()
    {
        for (int i = 0; i < ennemis.Count; i++)
        {
            
        }
    }

    private void Update()
    {
        ennemis = e.ennemisÀJour.;
        position = transform.position;
        if(life <= 0 && difficulté == 1)
            RespawnerAprèsMort();
        if (life <= 0 && difficulté >= 2)
        {
            SceneManager.LoadScene(currentLevel);
        }
        if (Input.GetMouseButton(0) && )
        {
            
            estEnModeAttaque[0] = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint c = collision.GetContact(0);
        if (c.otherCollider.gameObject.layer == 9)
            c.otherCollider.gameObject.GetComponent<EnnemiScriptComponent>().life -= attaque;
    }
    
    void RespawnerAprèsMort()
       => transform.position = positionDépart;
}
