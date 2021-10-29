using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private int _MovementSpeed;
    private InputManager _inputManager;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private Dir _dir;


    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _inputManager = GetComponent<InputManager>();
        _animator = GetComponent<Animator>();
    }
    private void Attack()
    {

        Vector2 vector = _inputManager._inputs.BasicMovement.MovementVector.ReadValue<Vector2>();
        if (_inputManager.isAttacking) Debug.Log(1);
    }

    private void movePlayer()
    {
        Vector2 vector = _inputManager._inputs.BasicMovement.MovementVector.ReadValue<Vector2>();
        gameObject.transform.Translate(vector* Time.deltaTime*_MovementSpeed);
        _animator.SetBool("isMovingUp", vector.y > 0);
        _animator.SetBool("isMovingDown", vector.y < 0);
        _animator.SetBool("isMovingSideways", vector.x < 0|| vector.x > 0);
        if (vector.x > 0)
        {
            _sprite.flipX = true;
            _dir = Dir.right;
        }
        else
        {
            _dir = Dir.left;
            _sprite.flipX = false;
        } 
        if (vector.y > 0)
        {
            _dir = Dir.top;
        }
        else
        {
            _dir = Dir.bottom;
        }

    }
    // Update is called once per frame
    void Update()
    {
        movePlayer();
        Attack();
    }
    enum Dir {right,top,left,bottom }
}
