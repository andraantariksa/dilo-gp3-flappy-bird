using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;
    private Rigidbody2D rigidbody2D = null;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(speed, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
        Destroy(gameObject);
    }
}
