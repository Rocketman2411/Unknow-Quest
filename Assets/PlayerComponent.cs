using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : MonoBehaviour
{
    public int life;
    public int attaque;
    public Vector3 position;
    public Vector3 positionDépart;

    private void Awake()
    {
        positionDépart = transform.position;
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
        if (c.otherCollider.gameObject.layer == 7)
        {
            c.otherCollider.gameObject.GetComponent<EnnemiScriptComponent>().life -= attaque;
        }
    }
    
    void RespawnerAprèsMort()
    {
        transform.position = positionDépart;
        
    }
}
