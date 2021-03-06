﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private Bird bird = null;
    [SerializeField]
    private float speed = 1.0f;
    
    private Collider2D collider = null;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!bird.IsDead)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Bird birdCollideWith = other.gameObject.GetComponent<Bird>();
        if (birdCollideWith)
        {
            collider.enabled = false;
            birdCollideWith.Dead();
        }

        FireBall fireBallCollideWith = other.gameObject.GetComponent<FireBall>();
        if (fireBallCollideWith)
        {
            fireBallCollideWith.Explode();
            Destroy(gameObject);
        }
    }
}
