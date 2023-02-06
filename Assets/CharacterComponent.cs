using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<LifeComponent>().AddComponent<DégatComponent>();
    }
}
