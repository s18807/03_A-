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
    private Dir _dir=Dir.bottom;
    private float time=1;
    [SerializeField]private GameObject _dager;


    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _inputManager = GetComponent<InputManager>();
        _animator = GetComponent<Animator>();
    }
    private void Attack()
    {
        time += Time.deltaTime;
        if (_inputManager.isAttacking && time > 1f) {
            time = 0;
            switch (_dir)
            {
                case Dir.right:
                    GameObject dag1 = Instantiate(_dager,this.transform.position+Vector3.right,Quaternion.Euler(0,0,((int)_dir)*90));
                    dag1.GetComponent<DaggerScript>().Move(Vector3.right);
                    break;
                case Dir.top:
                    GameObject dag2 = Instantiate(_dager, this.transform.position + Vector3.up, Quaternion.Euler(0, 0, ((int)_dir) * 90));
                    dag2.GetComponent<DaggerScript>().Move(Vector3.up);
                    break;
                case Dir.left:
                    GameObject dag3 = Instantiate(_dager, this.transform.position + Vector3.left, Quaternion.Euler(0, 0, ((int)_dir) * 90));
                    dag3.GetComponent<DaggerScript>().Move(Vector3.left);
                    break;
                case Dir.bottom:
                    GameObject dag4 = Instantiate(_dager, this.transform.position + Vector3.down, Quaternion.Euler(0, 0, ((int)_dir) * 90));
                    dag4.GetComponent<DaggerScript>().Move(Vector3.down);
                    break;
            }
        }
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
        else if (vector.x < 0)
        {
            _dir = Dir.left;
            _sprite.flipX = false;
        } 
        if (vector.y > 0)
        {
            _dir = Dir.top;
        }
        else if(vector.y < 0)
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
