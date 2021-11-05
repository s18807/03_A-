using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerScript : MonoBehaviour
{
    private Vector3 movementVector=Vector3.zero;
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position = transform.position += movementVector*speed * Time.deltaTime;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("XD");
        if (collision.gameObject.tag == "Enemy") Destroy(collision.gameObject);
        if (collision.gameObject.tag != "Player") Destroy(gameObject);
    }

    internal void Move(Vector3 x)
    {
        movementVector = x;
    }
}
