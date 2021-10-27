using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int _MovementSpeed;
    private InputManager _inputManager;

    private void Start()
    {
        _inputManager = GetComponent<InputManager>();
      
    }
    private void Attack()
    {
        if (_inputManager.isAttacking) Debug.Log(1);
    }

    private void movePlayer()
    {
        gameObject.transform.Translate(_inputManager._inputs.BasicMovement.MovementVector.ReadValue<Vector2>()* Time.deltaTime*_MovementSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }
}
