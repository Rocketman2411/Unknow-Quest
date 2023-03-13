using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]float attackRange;
    [SerializeField] private GameObject _gameObject;
    
    private Animator _animator;
    private Vector3 pos;
    
    public void Attaking()
    {
        if (pos.x >= 1)
        {
            _animator.SetBool("IsAttacking", true);
        }
        _animator.SetBool("IsAttacking ", false);
        
    }
    void Update()
    {
        pos = _gameObject.transform.position;
        Attaking();
    }
}
