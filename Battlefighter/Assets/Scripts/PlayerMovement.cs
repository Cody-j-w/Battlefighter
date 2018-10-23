using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bounds
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    public float speed;
    public Bounds bounds;
    public GameObject shot;
    public Transform BoltGun;
    public float fireRate = 0.5F;
    private float fireDelay = 0.0F;
    

    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > fireDelay)
        {
            fireDelay = Time.time + fireRate;
            Instantiate(shot, BoltGun.position, BoltGun.rotation);
        }
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 PlayerInput = new Vector3(moveHorizontal, moveVertical, 0.0f);

        rigidBody2D = GetComponent<Rigidbody2D>();
        rigidBody2D.velocity = PlayerInput * speed;

        rigidBody2D.position = new Vector3
            (
                Mathf.Clamp(rigidBody2D.position.x, bounds.xMin, bounds.xMax),
                Mathf.Clamp(rigidBody2D.position.y, bounds.yMin, bounds.yMax),
                0.0f
            );
    }
}
