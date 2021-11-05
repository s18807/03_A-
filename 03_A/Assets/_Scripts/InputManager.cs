using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerControlls _inputs;

    public Action OnMovementVector;
    public Action OnAttack;
    public Vector2 MovementVector;
    public bool isAttacking;
    // Start is called before the first frame update
    private void OnEnable()
    {
        _inputs = new PlayerControlls();
        _inputs.Enable();

        OnMovementVector += GetMovementVector;
        OnAttack += isAttack;
    }
    private void Start()
    {
        _inputs.BasicMovement.MovementVector.performed += _ => OnMovementVector?.Invoke();
        _inputs.BasicMovement.Attack.performed += _ => OnAttack?.Invoke();
    }
    private void OnDisable()
    {
        _inputs.Disable();   
    }
    private void isAttack()
    {
        isAttacking = _inputs.BasicMovement.Attack.ReadValue<float>()==1;
    }


    private void GetMovementVector()
    {
        MovementVector = _inputs.BasicMovement.MovementVector.ReadValue<Vector2>();
    }
}
