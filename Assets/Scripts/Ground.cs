using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Ground : MonoBehaviour
{
    [SerializeField]
    private Bird bird = null;
    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private Transform nextPos = null;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!bird || !bird.IsDead)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    public void SetNextGround(GameObject ground)
    {
        ground.transform.position = nextPos.position;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Bird birdCollideWith = other.gameObject.GetComponent<Bird>();
        if (birdCollideWith)
        {
            birdCollideWith.Dead();
        }
    }
}
