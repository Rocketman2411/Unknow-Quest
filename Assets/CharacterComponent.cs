using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponent : MonoBehaviour
{
    private void Awake()
    {
        gameObject.AddComponent<LifeComponent>();
    }
}
