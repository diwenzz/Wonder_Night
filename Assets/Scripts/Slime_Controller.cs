using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class Slime_Controller : MonoBehaviour
{
    public int hp;
    public int atk;

    private Rigidbody2D rb;
    Vector2 movement;
    public float speed;

    // Use this for initialization
    void Start()
    {     
        rb = GetComponent<Rigidbody2D>();
        movement.x = transform.position.x;
        movement.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        
        Movement();
    }

    private void Movement()
    {
        
    }

}
