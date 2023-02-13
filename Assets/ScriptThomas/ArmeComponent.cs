using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArmeComponent : MonoBehaviour
{
    private Vector3 position;
    private bool estRemplacé;
    public List<ArmeComponent> armes;
    public List<GameObject> objetArmes;
    [SerializeField]private int armeRemplace;
    private void Awake()
    {
        position = transform.position;
        armes = FindObjectsOfType<ArmeComponent>().ToList();
        foreach (var arme in armes)
            objetArmes.Add(arme.gameObject);
    }

    private void Update()
    {
        position = transform.position;
        if(estRemplacé)
            RemplacerArme(armeRemplace);
    }

    public void RemplacerArme(int nouvArme)
        => objetArmes[nouvArme].transform.SetParent(FindObjectOfType<PlayerComponent>().gameObject.transform);
}
