using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DégatComponent : MonoBehaviour
{
    public int dégat { get; set; }
    private void Awake() => dégat = gameObject.layer;
        

    
}
