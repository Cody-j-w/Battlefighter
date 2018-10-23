using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBolt : MonoBehaviour {

    private Rigidbody2D rigidBody2D;
    public float speed;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = transform.up * speed;
    }
}
