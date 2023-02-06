using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeComponent : MonoBehaviour
{
    public int vie { get; set; }
    private void Awake() => vie = gameObject.layer * 10;
        

    
        
}
