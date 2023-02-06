using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    public int vie { get; set; }
    private void Awake() => vie = gameObject.layer * 10;
        

    public void ChangerVie(int points) => vie += points; // pour perdre des points de vie, mettre un int négatif
        
}
