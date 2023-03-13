using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionInput : MonoBehaviour
{
    private PlayerAction _playerAction;
    private PlayerAttack _playerAttack; //script pour que le joeur attack un enemie à une certaine distance

    private void Awake()
    {
        _playerAttack = FindObjectOfType<PlayerAttack>();
    }

    private void OnEnable()
    {
        if (_playerAction == null)
        {
            _playerAction = new PlayerAction();
            _playerAction.CombatAction.Attack.performed += i => Attack();
        }
        _playerAction.Enable();
    }

    private void OnDisable()
    {
        _playerAction.Disable();
    }

    private void Attack()
    {
        _playerAttack.Attaking();
    }
}
