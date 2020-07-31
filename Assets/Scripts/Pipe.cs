using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private Bird bird;
    [SerializeField]
    private float speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

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
        Bird bird = other.gameObject.GetComponent<Bird>();
        if (!bird)
        {
            return;
        }

        Collider2D collider = GetComponent<Collider2D>();
        if (collider)
        {
            collider.enabled = false;
        }

        bird.Dead();
    }
}
